using chatus.API.Entities;

namespace chatus.API.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ChatType Type { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
