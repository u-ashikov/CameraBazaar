namespace CameraBazaar.Web.Models.Account
{
	using Common;
	using System;
	using System.ComponentModel.DataAnnotations;

	public class EditUserViewModel
    {
		public string Id { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = CameraBazaarConstants.Display.Email)]
		public string Email { get; set; }

		[Required]
		[RegularExpression(CameraBazaarConstants.User.PhonePattern,
			ErrorMessage = CameraBazaarConstants.Error.PhoneFormat)]
		public string Phone { get; set; }

		[StringLength(CameraBazaarConstants.User.PasswordMaxLength, ErrorMessage = CameraBazaarConstants.Error.PasswordLength,
			MinimumLength = CameraBazaarConstants.User.PasswordMinLength)]
		[RegularExpression(CameraBazaarConstants.User.PasswordPattern
			, ErrorMessage = CameraBazaarConstants.Error.PasswordAvailableSymbols)]
		[DataType(DataType.Password)]
        [Display(Name = CameraBazaarConstants.Display.Password)]
        public string Password { get; set; }

		[DataType(DataType.Password)]
        [Display(Name = CameraBazaarConstants.Display.CurrentPassword)]
        public string CurrentPassword { get; set; }

		public DateTime? LastLoginTime { get; set; }

		public DateTime? FirstLoginTime { get; set; }
	}
}
