namespace chatus.API.Entities
{
    public class ChatEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<MessageEntity> Messages { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
