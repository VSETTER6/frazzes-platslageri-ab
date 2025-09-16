using System.ComponentModel.DataAnnotations;

namespace Application.DTOS.User.UpdateUser
{
    public class UpdatePasswordDTO
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare(nameof(NewPassword), ErrorMessage = "New passwords do not match. Rewrite your passwords and try again.")]
        public string ConfirmPassword { get; set; }


        public UpdatePasswordDTO(string oldPassword, string newPassword, string confirmPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }
    }
}
