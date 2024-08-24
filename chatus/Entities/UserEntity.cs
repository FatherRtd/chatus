namespace chatus.API.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public List<ChatEntity> Chats { get; set; }
        public List<MessageEntity> Messages { get; set; }
    }
}
