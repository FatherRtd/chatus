using chatus.API.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace chatus.API.Entities.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatDbContext _context;

        public ChatRepository(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<Chat?> GetById(Guid id)
        {
            var result =  await _context.Chats
                                        .Include(x => x.Messages)
                                        .Include(x => x.Users)
                                        .FirstOrDefaultAsync(x => x.Id == id);

            return result?.Adapt<Chat>();
        }

        public async Task<IEnumerable<Chat>> GetByUserId(Guid userId)
        {
            var result = await _context.Chats
                                       .Include(x => x.Messages)
                                       .Include(x => x.Users)
                                       .Where(x => x.Users.Any(u => u.Id == userId))
                                       .ToListAsync();

            return result.Adapt<IEnumerable<Chat>>();
        }

        public async Task Add(Chat chat)
        {
            var userEntities = chat.Users.Select(x => new UserEntity
            {
                Id = x.Id,
            }).ToList();

            userEntities.ForEach(x => _context.Users.Attach(x));

            var messageEntities = new List<MessageEntity>();

            if (chat.Messages.Any())
            {
                messageEntities = chat.Messages.Select(x => new MessageEntity
                {
                    Text = x.Text,
                    User = userEntities.Find(u => u.Id == x.User.Id)
                }).ToList();
            }

            var chatEntity = new ChatEntity
            {
                Name = chat.Name,
                Users = userEntities,
                Type = chat.Type,
                Messages = messageEntities
            };

            await _context.Chats.AddAsync(chatEntity);
            await _context.SaveChangesAsync();
        }
    }
}
