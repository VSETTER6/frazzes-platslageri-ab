using System.ComponentModel.DataAnnotations;

namespace Application.DTOS.User.AddUser
{
    public class AddUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public AddUserDTO(string firstName, string lastName, string userName, string email, string password, string phoneNumber, DateTime createdAt)
        {
            LastName = lastName;
            FirstName = firstName;
            UserName = userName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            CreatedAt = createdAt;
        }
    }
}
