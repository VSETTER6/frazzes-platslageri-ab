using Application.DTOS.User.DeleteUser;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public record class DeleteUserCommand(DeleteUserDTO DeleteUserDto) : IRequest<OperationResult<User>>;
}
