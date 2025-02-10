using Application.DTOS.GetUserByIdDTO;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, OperationResult<GetUserByIdDTO>>
    {
        private readonly ICrudRepository<User> _userRepository;

        public GetUserByIdQueryHandler(ICrudRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<GetUserByIdDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id);

                if (user == null)
                {
                    return OperationResult<GetUserByIdDTO>.Failed($"User with ID {request.Id} was not found.");
                }
                else
                {
                    var userByIdDto = new GetUserByIdDTO(
                        user.Id,
                        user.FirstName,
                        user.LastName
                        );

                    return OperationResult<GetUserByIdDTO>.Successful(userByIdDto);
                }
            }
            catch (Exception) 
            {
                return OperationResult<GetUserByIdDTO>.Failed("An error occurred while getting the user.");
            }
        }
    }
}
