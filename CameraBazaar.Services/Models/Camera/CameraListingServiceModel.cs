namespace CameraBazaar.Services.Models.Camera
{
	public class CameraListingServiceModel
    {
		public int Id { get; set; }

		public string Make { get; set; }

		public string Model { get; set; }

		public decimal Price { get; set; }

		public bool InStock { get; set; }

		public string ImageUrl { get; set; }

		public string Seller { get; set; }
    }
}
