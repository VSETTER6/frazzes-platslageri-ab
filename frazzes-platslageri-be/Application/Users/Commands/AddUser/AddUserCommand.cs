using Application.DTOS.AddUser;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.AddUser
{
    public record class AddUserCommand(AddUserDTO AddUserDto) : IRequest<OperationResult<User>>;
}
