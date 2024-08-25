using chatus.API.Models;

namespace chatus.API.Entities.Repositories;

public interface IUserRepository
{
    Task<User> GetById(Guid id);
    Task<User> GetByLogin(string login);
    Task Add(User user);
}