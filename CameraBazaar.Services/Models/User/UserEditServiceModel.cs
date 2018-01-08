namespace CameraBazaar.Services.Models.User
{
	using System;

	public class UserEditServiceModel
    {
		public string Id { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public DateTime? FirstLoginTime { get; set; }

		public DateTime? LastLoginTime { get; set; }
	}
}
