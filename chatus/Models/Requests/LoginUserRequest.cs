using System.ComponentModel.DataAnnotations;

namespace chatus.API.Models.Requests
{
    public record LoginUserRequest(
        [Required] string Login,
        [Required] string Password);
}
