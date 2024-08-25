using chatus.API.Contracts;
using chatus.API.Entities.Repositories;
using chatus.API.Models;
using chatus.API.Utils;

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

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task Register(string login, string password, string userName)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = hashedPassword,
                UserName = userName,
            };

            await _userRepository.Add(newUser);
        }

        public async Task<string> Login(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            var result = _passwordHasher.Verify(password, user.Password);

            if (result == false)
            {
                throw new Exception("Wrong login or password");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
