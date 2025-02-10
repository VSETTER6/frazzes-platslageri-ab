using Application.DTOS.User.GetAllUsers;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsers
{
    public record class GetAllUsersQuery : IRequest<OperationResult<List<GetAllUsersDTO>>>;
}
