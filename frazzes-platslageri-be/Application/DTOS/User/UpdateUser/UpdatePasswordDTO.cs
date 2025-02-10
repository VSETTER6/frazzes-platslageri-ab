using System.ComponentModel.DataAnnotations;

namespace Application.DTOS.User.UpdateUser
{
    public class UpdatePasswordDTO
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }

        public UpdatePasswordDTO(string oldPassword, string newPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }
}
