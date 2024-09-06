using System.ComponentModel.DataAnnotations;

namespace chatus.API.Models.Requests
{
    public record RegisterUserRequest(
        [Required] string Login,
        [Required] string Password,
        [Required] string UserName);
}
