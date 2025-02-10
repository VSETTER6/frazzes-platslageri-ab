using Application.DTOS.GetAllUsersDTO;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsers
{
    public record class GetAllUsersQuery : IRequest<OperationResult<List<GetAllUsersDTO>>>;
}
