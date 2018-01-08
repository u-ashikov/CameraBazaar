namespace CameraBazaar.Web.Models.Account
{
    using Common;
	using System.ComponentModel.DataAnnotations;

	public class LoginWith2faViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = CameraBazaarConstants.Error.TwoFactorCode, MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = CameraBazaarConstants.Display.AuthenticatorCode)]
        public string TwoFactorCode { get; set; }

       [Display(Name = CameraBazaarConstants.Display.RememberThisMachine)]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
    }
}
