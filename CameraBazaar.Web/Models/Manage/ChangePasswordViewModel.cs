namespace CameraBazaar.Web.Models.Manage
{
    using Common;
	using System.ComponentModel.DataAnnotations;

	public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = CameraBazaarConstants.Display.CurrentPassword)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(CameraBazaarConstants.User.PasswordMaxLength, ErrorMessage = CameraBazaarConstants.Error.PasswordLength, MinimumLength = CameraBazaarConstants.User.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = CameraBazaarConstants.Display.NewPassword)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = CameraBazaarConstants.Display.ConfirmNewPassword)]
        [Compare("NewPassword", ErrorMessage = CameraBazaarConstants.Error.NewPasswordAndConfirmPasswordMismatch)]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
