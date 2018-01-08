namespace CameraBazaar.Web.Models.Account
{
	using Common;
	using CameraBazaar.Infrastructure.Attributes.Validation.User;
	using System.ComponentModel.DataAnnotations;

	public class RegisterViewModel
    {
		[Required]
		[Username(ErrorMessage = CameraBazaarConstants.Error.UsernameAvailableSymbols)]
		[StringLength(CameraBazaarConstants.User.UsernameMaxLength,
			MinimumLength = CameraBazaarConstants.User.UsernameMinLength,
			ErrorMessage = CameraBazaarConstants.Error.UsernameLength)]
		public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = CameraBazaarConstants.Display.Email)]
        public string Email { get; set; }

		[Required]
		[RegularExpression(CameraBazaarConstants.User.PhonePattern,
			ErrorMessage = CameraBazaarConstants.Error.PhoneFormat)]
		public string Phone { get; set; }

        [Required]
        [StringLength(CameraBazaarConstants.User.PasswordMaxLength, ErrorMessage = CameraBazaarConstants.Error.PasswordLength, 
			MinimumLength = CameraBazaarConstants.User.PasswordMinLength)]
		[RegularExpression(CameraBazaarConstants.User.PasswordPattern
			,ErrorMessage = CameraBazaarConstants.Error.PasswordAvailableSymbols)]
        [DataType(DataType.Password)]
        [Display(Name = CameraBazaarConstants.Display.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = CameraBazaarConstants.Display.ConfirmPassword)]
        [Compare("Password", ErrorMessage = CameraBazaarConstants.Error.PasswordsMatch)]
        public string ConfirmPassword { get; set; }
    }
}
