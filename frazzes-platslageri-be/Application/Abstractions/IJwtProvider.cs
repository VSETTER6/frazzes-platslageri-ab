using Domain.Models;

namespace Application.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateJwt(User user);
    }
}
