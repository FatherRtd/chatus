using chatus.API.Dto;
using chatus.API.Errors;
using CSharpFunctionalExtensions;

namespace chatus.API.Services
{
    public interface IUserService
    {
        Task<UnitResult<Error>> Register(string login, string password, string userName);
        Task<Result<string, Error>> Login(string login, string password);
        Task<Result<UserDto, Error>> GetById(Guid id);
    }
}
