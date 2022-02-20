using System.ComponentModel.DataAnnotations;

namespace Models.Identity
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "User is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm new password is required")]
        public string ConfirmNewPassword { get; set; }
        public string Token { get; set; }
    }
}
