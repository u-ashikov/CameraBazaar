namespace CameraBazaar.Data.Models
{
    using Common;
    using Enums;
    using System.ComponentModel.DataAnnotations;

    public class Camera
    {
		public int Id { get; set; }

		[Required]
		public Make Make { get; set; }

		[Required]
		[MinLength(CameraBazaarConstants.Camera.ModelMinLength)]
		[MaxLength(CameraBazaarConstants.Camera.ModelMaxLength)]
		public string Model { get; set; }

		[Range(0,double.MaxValue)]
		public decimal Price { get; set; }

		[Range(CameraBazaarConstants.Camera.MinQuantity,CameraBazaarConstants.Camera.MaxQuantity)]
		public int Quantity { get; set; }

		[Range(CameraBazaarConstants.Camera.MinShutterSpeedMin,CameraBazaarConstants.Camera.MinShutterSpeedMax)]
		public int MinShutterSpeed { get; set; }

		[Range(CameraBazaarConstants.Camera.MaxShutterSpeedMin,CameraBazaarConstants.Camera.MaxShutetrSpeedMax)]
		public int MaxShutterSpeed { get; set; }

		public int MinIso { get; set; }

		[Range(CameraBazaarConstants.Camera.MaxIsoMin,CameraBazaarConstants.Camera.MaxIsoMax)]
		public int MaxIso { get; set; }

		public bool IsFullFrame { get; set; }

		[Required]
		[MaxLength(CameraBazaarConstants.Camera.VideoResolutionMaxLength)]
		public string VideoResolution { get; set; }

		[Required]
		public LightMetering LightMetering { get; set; }

		[Required]
		[MaxLength(CameraBazaarConstants.Camera.DescriptionMaxLength)]
		public string Description { get; set; }

		[Required]
		[MinLength(CameraBazaarConstants.Camera.UrlMinLength)]
		[MaxLength(CameraBazaarConstants.Camera.UrlMaxLength)]
		public string ImageUrl { get; set; }

		[Required]
		public string UserId { get; set; }

		public User User { get; set; }
    }
}
