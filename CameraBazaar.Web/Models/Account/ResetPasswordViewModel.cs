namespace CameraBazaar.Web.Models.Account
{
    using Common;
	using System.ComponentModel.DataAnnotations;

	public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(CameraBazaarConstants.User.PasswordMaxLength, ErrorMessage = CameraBazaarConstants.Error.PasswordLength, MinimumLength = CameraBazaarConstants.User.PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = CameraBazaarConstants.Display.ConfirmPassword)]
        [Compare("Password", ErrorMessage = CameraBazaarConstants.Error.PasswordsMatch)]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
