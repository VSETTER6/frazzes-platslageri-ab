using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, OperationResult<User>>
    {
        private readonly ICrudRepository<User> _userRepository;

        public DeleteUserCommandHandler(ICrudRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.DeleteUserDto.Id);
                if (user == null)
                {
                    return OperationResult<User>.Failed($"User with ID {request.DeleteUserDto.Id} was not found.");
                }
                else
                {
                    await _userRepository.DeleteAsync(user.Id);
                    return OperationResult<User>.Successful(user);
                }
            }
            catch (Exception)
            {
                return OperationResult<User>.Failed("An error occurred while deleting the user.");
            }
        }
    }
}
