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
            try
            {
                var users = await _userRepository.GetAllAsync();

                if (users == null)
                {
                    return OperationResult<List<GetAllUsersDto>>.Failed("No users found.");
                }
                else
                {
                    var userDto = users.Select(user => new GetAllUsersDto(
                        user.FirstName,
                        user.LastName,
                        user.Email ?? string.Empty,
                        user.PhoneNumber ?? string.Empty
                        )).ToList();

                    return OperationResult<List<GetAllUsersDto>>.Successful(userDto);
                }
            }
            catch (Exception ex)
            {
                return OperationResult<List<GetAllUsersDto>>.Failed("An error occurred while getting the users." + ex);
            }
        }
    }
}
