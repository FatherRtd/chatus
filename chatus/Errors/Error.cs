namespace chatus.API.Errors
{
    public record Error(string Code, string Message)
    {
        public static Error None => new Error(string.Empty, string.Empty);
    }
}
