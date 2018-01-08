namespace CameraBazaar.Infrastructure.Attributes.Validation.Camera
{
    using Common;
	using System.ComponentModel.DataAnnotations;

	public class MinIsoAttribute : ValidationAttribute
    {
		public override bool IsValid(object value)
		{
			int minIso = (int)value;

			return minIso == CameraBazaarConstants.Camera.MinIsoMin
				|| minIso == CameraBazaarConstants.Camera.MinIsoMax;
		}
	}
}
