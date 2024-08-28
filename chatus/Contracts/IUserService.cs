using chatus.API.Models;
using CSharpFunctionalExtensions;

namespace chatus.API.Contracts
{
    public interface IUserService
    {
        Task<Result> Register(string login, string password, string userName);
        Task<Result<string>> Login(string login, string password);
        Task<Result<User>> GetById(Guid id);
    }
}
