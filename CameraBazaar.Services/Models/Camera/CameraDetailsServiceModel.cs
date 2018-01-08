namespace CameraBazaar.Services.Models.Camera
{
	using System.Collections.Generic;

	public class CameraDetailsServiceModel : CameraListingServiceModel
    {
		public string IsFullFrame { get; set; }

		public int MinShutterSpeed { get; set; }

		public int MaxShutterSpeed { get; set; }

		public int MinIso { get; set; }

		public int MaxIso { get; set; }

		public string VideoResolution { get; set; }

		public IList<string> LightMeterings { get; set; }

		public string Description { get; set; }

		public string SellerId { get; set; }
	}
}
