namespace chatus.API.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Chat Chat { get; set; }
    }
}
