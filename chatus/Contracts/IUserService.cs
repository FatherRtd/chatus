using chatus.API.Models;

namespace chatus.API.Contracts
{
    public interface IUserService
    {
        Task Register(string login, string password, string userName);
        Task<string> Login(string login, string password);
        Task<User> GetById(Guid id);
    }
}
