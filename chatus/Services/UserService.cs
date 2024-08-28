using chatus.API.Contracts;
using chatus.API.Entities.Repositories;
using chatus.API.Models;
using chatus.API.Utils;
using CSharpFunctionalExtensions;

namespace chatus.API.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<User>> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return Result.Failure<User>($"Пользователь с id = {id} не найден");
            }

            return user;
        }

        public async Task<Result> Register(string login, string password, string userName)
        {
            var user = await _userRepository.GetByLogin(login);

            if (user != null)
            {
                return Result.Failure("Пользователь с таким логином уже существует");
            }

            var hashedPassword = _passwordHasher.Generate(password);

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = hashedPassword,
                UserName = userName,
            };

            await _userRepository.Add(newUser);

            return Result.Success();
        }

        public async Task<Result<string>> Login(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            if (user == null)
            {
                return Result.Failure<string>("Неверный логин или пароль");
            }

            var result = _passwordHasher.Verify(password, user.Password);

            if (result == false)
            {
                return Result.Failure<string>("Неверный логин или пароль");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
