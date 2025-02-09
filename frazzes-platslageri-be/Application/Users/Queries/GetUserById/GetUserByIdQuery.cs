using Application.DTOS.GetUserById;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetUserById
{
    public record class GetUserByIdQuery(Guid Id) : IRequest<OperationResult<GetUserByIdDto>>;
}
