using chatus.API.Dto;
using chatus.API.Errors;
using CSharpFunctionalExtensions;

namespace chatus.API.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatDto>, Error>> GetUserChats(Guid userId);
        Task<UnitResult<Error>> CreateDialogue(Guid userId, Guid memberId, string initialMessage);
        Task<UnitResult<Error>> CreateGroup(string chatName, Guid userId);
    }
}
