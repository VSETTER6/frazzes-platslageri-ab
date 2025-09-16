using Domain.Models;

namespace Application.Abbstractions
{
    public interface IJwtProvider
    {
        string GenerateJwt(User user);
    }
}
