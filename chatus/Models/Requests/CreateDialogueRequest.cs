namespace chatus.API.Models.Requests
{
    public class CreateDialogueRequest
    {
        public string MemberId { get; set; } = string.Empty;
        public string InitialMessage { get; set; } = string.Empty;
    }
}
