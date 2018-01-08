namespace CameraBazaar.Web.Models.Account
{
    using Common;
	using System.ComponentModel.DataAnnotations;

	public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = CameraBazaarConstants.Display.RememberMe)]
        public bool RememberMe { get; set; }
    }
}
