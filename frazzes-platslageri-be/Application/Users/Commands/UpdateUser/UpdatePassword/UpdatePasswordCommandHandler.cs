using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Users.Commands.UpdateUser.UpdatePassword
{
    public sealed class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, OperationResult<User>>
    {
        private readonly ICrudRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdatePasswordCommandHandler(ICrudRepository<User> userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<OperationResult<User>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
                if (userIdClaim == null)
                {
                    return OperationResult<User>.Failed("Unauthorized");
                }

                var userId = Guid.Parse(userIdClaim);

                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return OperationResult<User>.Failed("User not found.");
                }

                if (!VerifyPassword(user.PasswordHash, request.UpdatePasswordDto.OldPassword))
                    return OperationResult<User>.Failed("Incorrect password.");

                user.PasswordHash = HashPassword(request.UpdatePasswordDto.NewPassword);
                await _userRepository.UpdateAsync(user);

                return OperationResult<User>.Successful(user);

            }
            catch (Exception)
            {
                return OperationResult<User>.Failed("An error occurred while updating the password.");
            }
        }

        private bool VerifyPassword(string storedHash, string providedPassword)
        {
            return storedHash == providedPassword;
        }

        private string HashPassword(string password)
        {
            return password;
        }
    }
}
