using chatus.API.Dto;
using chatus.API.Entities.Repositories;
using chatus.API.Errors;
using chatus.API.Errors.User;
using chatus.API.Models;
using chatus.API.Utils;
using CSharpFunctionalExtensions;
using Mapster;

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

        public async Task<Result<UserDto, Error>> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return UserErrors.MissingId(id);
            }

            return user.Adapt<UserDto>();
        }

        public async Task<UnitResult<Error>> Register(string login, string password, string userName)
        {
            var user = await _userRepository.GetByLogin(login);

            if (user != null)
            {
                return UserErrors.LoginExists;
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

            return UnitResult.Success<Error>();
        }

        public async Task<Result<string, Error>> Login(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            if (user == null)
            {
                return UserErrors.WrongLoginOrPassword;
            }

            var result = _passwordHasher.Verify(password, user.Password);

            if (result == false)
            {
                return UserErrors.WrongLoginOrPassword;
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
