using Application.DTOS.User.UpdateUser;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.UpdateUser.UpdatePassword
{
    public record class UpdatePasswordCommand(UpdatePasswordDTO UpdatePasswordDto) : IRequest<OperationResult<User>>;
}
