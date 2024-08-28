using chatus.API.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace chatus.API.Entities.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatDbContext _context;

        public UserRepository(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetById(Guid id)
        {
            var result = await _context.Users.AsNoTracking()
                                       .FirstOrDefaultAsync(x => x.Id == id);

            return result?.Adapt<User>();
        }

        public async Task<User?> GetByLogin(string login)
        {
            var result = await _context.Users
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(x => x.Login == login);

            return result?.Adapt<User>();
        }

        public async Task Add(User user)
        {
            var userEntity = new UserEntity
            {
                UserName = user.UserName,
                Login = user.Login,
                Password = user.Password
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }
    }
}
