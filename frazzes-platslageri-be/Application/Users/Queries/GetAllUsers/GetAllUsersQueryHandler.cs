using Application.DTOS.GetAllUsers;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, OperationResult<List<GetAllUsersDto>>>
    {
        private readonly ICrudRepository<User> _userRepository;

        public GetAllUsersQueryHandler(ICrudRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<List<GetAllUsersDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            if (users == null)
            {
                return OperationResult<List<GetAllUsersDto>>.Failed("An error occurred while getting the users.");
            }
            else
            {
                var userDto = users.Select(user => new GetAllUsersDto(user.Id, user.FirstName, user.LastName)).ToList();
                return OperationResult<List<GetAllUsersDto>>.Successful(userDto);
            }
        }
    }
}
