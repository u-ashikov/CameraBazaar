namespace CameraBazaar.Infrastructure.Attributes.Validation.Camera
{
	using Common;
	using System.ComponentModel.DataAnnotations;

	public class MaxIsoAttribute : ValidationAttribute
    {
		public override bool IsValid(object value)
		{
			int maxIso = (int)value;

			return maxIso >= CameraBazaarConstants.Camera.MaxIsoMin
				&& maxIso <= CameraBazaarConstants.Camera.MaxIsoMax
				&& maxIso % 100 == 0;
		}
	}
}
