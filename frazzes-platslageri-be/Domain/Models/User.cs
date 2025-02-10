using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public new required string UserName { get; set; }
        [Required]
        public new required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public new string? PhoneNumber { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        public User() : base()
        {
        }

        public User(Guid id, string firstName, string lastName, string email, string userName, string password, string? phoneNumber) : base()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
