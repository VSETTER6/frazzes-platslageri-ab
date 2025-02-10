using Application.DTOS.User.GetAllUsers;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsers
{
    public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, OperationResult<List<GetAllUsersDTO>>>
    {
        private readonly ICrudRepository<User> _userRepository;

        public GetAllUsersQueryHandler(ICrudRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<List<GetAllUsersDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAllAsync();

                if (users == null)
                {
                    return OperationResult<List<GetAllUsersDTO>>.Failed("No users found.");
                }
                else
                {
                    var allUsersDto = users.Select(user => new GetAllUsersDTO(
                        user.FirstName,
                        user.LastName,
                        user.Email ?? string.Empty,
                        user.PhoneNumber ?? string.Empty
                        )).ToList();

                    return OperationResult<List<GetAllUsersDTO>>.Successful(allUsersDto);
                }
            }
            catch (Exception)
            {
                return OperationResult<List<GetAllUsersDTO>>.Failed("An error occurred while getting the users.");
            }
        }
    }
}
