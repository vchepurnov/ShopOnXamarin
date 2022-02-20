using System.ComponentModel.DataAnnotations;

namespace Identity_Server.Models
{
    public class ResetPasswordAdminModel
    {
        [Required(ErrorMessage = "User is required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="New password is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm new password is required")]
        public string ConfirmNewPassword { get; set; }
    }
}
