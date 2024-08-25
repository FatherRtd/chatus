using System.ComponentModel.DataAnnotations;

namespace chatus.API.Models
{
    public record RegisterUserRequest(
        [Required] string Login,
        [Required] string Password,
        [Required] string UserName);
}
