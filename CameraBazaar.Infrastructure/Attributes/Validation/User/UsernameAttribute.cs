namespace CameraBazaar.Infrastructure.Attributes.Validation.User
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class UsernameAttribute : ValidationAttribute
    {
		public override bool IsValid(object value)
		{
			string username = value as string;

			return !username.Any(c => !char.IsLetter(c));
		}
	}
}
