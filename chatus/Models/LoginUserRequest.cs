using System.ComponentModel.DataAnnotations;

namespace chatus.API.Models
{
    public record LoginUserRequest(
        [Required] string Login,
        [Required] string Password);
}
