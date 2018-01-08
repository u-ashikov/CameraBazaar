namespace CameraBazaar.Services.Models.Camera
{
	using Data.Enums;

	public class CameraEditServiceModel
    {
		public Make Make { get; set; }

		public string Model { get; set; }

		public decimal Price { get; set; }

		public int Quantity { get; set; }

		public int MinShutterSpeed { get; set; }

		public int MaxShutterSpeed { get; set; }

		public int MinIso { get; set; }

		public int MaxIso { get; set; }

		public bool IsFullFrame { get; set; }

		public string VideoResolution { get; set; }

		public LightMetering LightMetering { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }
	}
}
