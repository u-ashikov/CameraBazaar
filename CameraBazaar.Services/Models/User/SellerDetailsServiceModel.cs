namespace CameraBazaar.Services.Models.User
{
	using Camera;
	using System;
	using System.Collections.Generic;

	public class SellerDetailsServiceModel
    {
		public string Id { get; set; }

		public string Username { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public int CamerasInStock { get; set; }

		public int CamerasOutOfStock { get; set; }

		public DateTime? FirstLoginTime { get; set; }

		public DateTime? LastLoginTime { get; set; }

		public IEnumerable<CameraListingServiceModel> Cameras { get; set; }
    }
}
