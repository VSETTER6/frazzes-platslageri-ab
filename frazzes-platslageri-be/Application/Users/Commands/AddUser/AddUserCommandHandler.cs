using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.AddUser
{
    public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, OperationResult<User>>
    {
        private readonly ICrudRepository<User> _userRepository;

        public AddUserCommandHandler(ICrudRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<User>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.AddUserDto.FirstName) ||
                    string.IsNullOrWhiteSpace(request.AddUserDto.LastName) ||
                    string.IsNullOrWhiteSpace(request.AddUserDto.Email) ||
                    string.IsNullOrWhiteSpace(request.AddUserDto.UserName) ||
                    string.IsNullOrWhiteSpace(request.AddUserDto.Password))
                {
                    return OperationResult<User>.Failed("None of the required fields can be empty.");
                }
                else
                {
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.AddUserDto.Password);

                    User newUser = new()
                    {
                        FirstName = request.AddUserDto.FirstName,
                        LastName = request.AddUserDto.LastName,
                        Email = request.AddUserDto.Email,
                        UserName = request.AddUserDto.UserName,
                        Password = hashedPassword,
                        PhoneNumber = request.AddUserDto.PhoneNumber,
                        CreatedAt = request.AddUserDto.CreatedAt
                    };

                    await _userRepository.AddAsync(newUser);
                    return OperationResult<User>.Successful(newUser);
                }
            }
            catch (Exception)
            {
                return OperationResult<User>.Failed("An error occurred while adding the user.");
            }
        }
    }
}
