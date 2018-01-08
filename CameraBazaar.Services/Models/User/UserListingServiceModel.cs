namespace CameraBazaar.Services.Models.User
{
    using Common;
    using System.ComponentModel.DataAnnotations;

	public class UserListingServiceModel
    {
		public string Id { get; set; }

		public string Username { get; set; }

		public string Email { get; set; }

		[Display(Name = CameraBazaarConstants.Display.IsRestricted)]
		public bool IsRestricted { get; set; }
    }
}
