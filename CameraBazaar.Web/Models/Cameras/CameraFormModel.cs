namespace CameraBazaar.Web.Models.Cameras
{
    using CameraBazaar.Infrastructure.Attributes.Validation.Camera;
    using Common;
    using Data.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CameraFormModel
    {
		[Required]
		public Make Make { get; set; }

		[Required]
		[StringLength(CameraBazaarConstants.Camera.ModelMaxLength,
			MinimumLength = CameraBazaarConstants.Camera.ModelMinLength,
			ErrorMessage = CameraBazaarConstants.Error.CameraModelLength)]
		[RegularExpression(CameraBazaarConstants.Camera.ModelPattern,
			ErrorMessage = CameraBazaarConstants.Error.CameraModelAvailableSymbols)]
		public string Model { get; set; }

		[Range(0, double.MaxValue,ErrorMessage = CameraBazaarConstants.Error.CameraPrice)]
		public decimal Price { get; set; }

		[Range(CameraBazaarConstants.Camera.MinQuantity, CameraBazaarConstants.Camera.MaxQuantity)]
		public int Quantity { get; set; }

		[Display(Name = CameraBazaarConstants.Display.MinShutterSpeed)]
		[Range(CameraBazaarConstants.Camera.MinShutterSpeedMin, CameraBazaarConstants.Camera.MinShutterSpeedMax)]
		public int MinShutterSpeed { get; set; }

		[Display(Name = CameraBazaarConstants.Display.MaxShutterSpeed)]
		[Range(CameraBazaarConstants.Camera.MaxShutterSpeedMin, CameraBazaarConstants.Camera.MaxShutetrSpeedMax)]
		public int MaxShutterSpeed { get; set; }

		[Display(Name = CameraBazaarConstants.Display.MinIso)]
		[MinIso(ErrorMessage = CameraBazaarConstants.Error.MinIso)]
		public int MinIso { get; set; }

		[Display(Name = CameraBazaarConstants.Display.MaxIso)]
		[MaxIso(ErrorMessage = CameraBazaarConstants.Error.MaxIso)]
		public int MaxIso { get; set; }

		[Display(Name = CameraBazaarConstants.Display.IsFullFrame)]
		public bool IsFullFrame { get; set; }

		[Required]
		[Display(Name = CameraBazaarConstants.Display.VideoResolution)]
		[MaxLength(CameraBazaarConstants.Camera.VideoResolutionMaxLength,
			ErrorMessage = CameraBazaarConstants.Error.VideoResolution)]
		public string VideoResolution { get; set; }

		[Required]
		[Display(Name = CameraBazaarConstants.Display.LightMetering)]
		public IEnumerable<LightMetering> LightMeterings { get; set; }

		[Required()]
		[MaxLength(CameraBazaarConstants.Camera.DescriptionMaxLength)]
		public string Description { get; set; }

		[Required]
		[Display(Name = CameraBazaarConstants.Display.ImageUrl)]
		[StringLength(CameraBazaarConstants.Camera.UrlMaxLength,
			MinimumLength = CameraBazaarConstants.Camera.UrlMinLength)]
		[RegularExpression(CameraBazaarConstants.Camera.ImageUrlPattern
			,ErrorMessage = CameraBazaarConstants.Error.ImageUrl)]
		public string ImageUrl { get; set; }
	}
}
