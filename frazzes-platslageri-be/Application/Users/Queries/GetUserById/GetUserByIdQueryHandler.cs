using Application.DTOS.GetAllUsers;
using Application.DTOS.GetUserById;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, OperationResult<GetUserByIdDto>>
    {
        private readonly ICrudRepository<User> _userRepository;

        public GetUserByIdQueryHandler(ICrudRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<GetUserByIdDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id);

                if (user == null)
                {
                    return OperationResult<GetUserByIdDto>.Failed($"User with ID {request.Id} was not found.");
                }
                else
                {
                    var userByIdDto = new GetUserByIdDto(
                        user.Id,
                        user.FirstName,
                        user.LastName
                        );

                    return OperationResult<GetUserByIdDto>.Successful(userByIdDto);
                }
            }
            catch (Exception) 
            {
                return OperationResult<GetUserByIdDto>.Failed("An error occurred while getting the user.");
            }
        }
    }
}
