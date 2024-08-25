using chatus.API.Models;

namespace chatus.API.Utils;

public interface IJwtProvider
{
    string GenerateToken(User user);
}