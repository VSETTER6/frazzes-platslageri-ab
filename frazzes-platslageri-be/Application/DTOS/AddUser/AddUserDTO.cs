using System.ComponentModel.DataAnnotations;

namespace Application.DTOS.AddUser
{
    public class AddUserDTO
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }
    }
}
