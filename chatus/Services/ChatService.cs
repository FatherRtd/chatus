using chatus.API.Dto;
using chatus.API.Entities;
using chatus.API.Entities.Repositories;
using chatus.API.Errors;
using chatus.API.Models;
using CSharpFunctionalExtensions;
using Mapster;

namespace chatus.API.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        private readonly IUserRepository _userRepository;

        public ChatService(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<ChatDto>, Error>> GetUserChats(Guid userId)
        {
            var chats = await _chatRepository.GetByUserId(userId);

            foreach (var chat in chats)
            {
                if (chat.Type == ChatType.Dialogue)
                {
                    var dialogueMember = chat.Users.First(x => x.Id != userId);
                    chat.Name = dialogueMember.UserName;
                }
            }

            return chats.Adapt<ChatDto[]>();
        }

        public async Task<UnitResult<Error>> CreateDialogue(Guid userId, Guid memberId, string initialMessage)
        {
            var currentUser = new User { Id = userId };

            var chat = new Chat
            {
                Users = new[] { currentUser, new User { Id = memberId } },
                Type = ChatType.Dialogue,
                Name = string.Empty,
                Messages = new[] { new Message
                {
                    User = currentUser,
                    Text = initialMessage
                }}
            };

            await _chatRepository.Add(chat);

            return UnitResult.Success<Error>();
        }

        public async Task<UnitResult<Error>> CreateGroup(string chatName, Guid userId)
        {
            var chat = new Chat
            {
                Users = new[] { new User { Id = userId } },
                Type = ChatType.Group,
                Name = chatName,
                Messages = Array.Empty<Message>(),
            };

            await _chatRepository.Add(chat);

            return UnitResult.Success<Error>();
        }
    }
}
