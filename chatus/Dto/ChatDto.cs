namespace chatus.API.Dto
{
    public class ChatDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }
    }
}
