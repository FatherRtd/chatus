using chatus.API.Models;

namespace chatus.API.Entities.Repositories
{
    public interface IChatRepository
    {
        Task<Chat?> GetById(Guid id);
        Task<IEnumerable<Chat>> GetByUserId(Guid userId);
        Task Add(Chat chat);
    }
}
