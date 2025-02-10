using Application.DTOS.GetUserByIdDTO;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetUserById
{
    public record class GetUserByIdQuery(Guid Id) : IRequest<OperationResult<GetUserByIdDTO>>;
}
