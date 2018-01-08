namespace CameraBazaar.Web.Models.Manage
{
    using Common;
	using System.ComponentModel.DataAnnotations;

	public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = CameraBazaarConstants.Display.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
