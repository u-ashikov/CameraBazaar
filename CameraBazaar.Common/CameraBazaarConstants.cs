namespace CameraBazaar.Common
{
	public static class CameraBazaarConstants
    {
		public const string AdministratorRole = "Administrator";

		public const string AdminUserName = "admin";

		public const string AdminPassword = "admin";

		public const string AdminEmail = "admin@admin.com";

        public const string DefaultConnection = "DefaultConnection";

        public const int MinPageSize = 1;

        public class User
		{
			public const int PageSize = 10;

			public const int UsernameMinLength = 4;

			public const int UsernameMaxLength = 20;

			public const int PasswordMinLength = 3;

			public const int PasswordMaxLength = 100;

			public const int PhoneMinLength = 10;

			public const int PhoneMaxLength = 12;

			public const string PhonePattern = @"^\+\d{10,12}$";

			public const string PasswordPattern = @"[a-z0-9]{3,}";

			public const string AnnonymousUser = "Annonymous";
		}

		public class Camera
		{
			public const int PageSize = 5;

			public const int ModelMinLength = 1;

			public const int ModelMaxLength = 100;

			public const int MinQuantity = 0;

			public const int MaxQuantity = 100;

			public const int MinShutterSpeedMin = 1;

			public const int MinShutterSpeedMax = 30;

			public const int MaxShutterSpeedMin = 2000;

			public const int MaxShutetrSpeedMax = 8000;

			public const int MinIsoMin = 50;

			public const int MinIsoMax = 100;

			public const int MaxIsoMin = 200;

			public const int MaxIsoMax = 409600;

			public const int VideoResolutionMaxLength = 15;

			public const int DescriptionMaxLength = 6000;

			public const int UrlMinLength = 11;

			public const int UrlMaxLength = 2000;

			public const string ImageUrlPattern = @"^(?:http|https):\/\/.+$";

			public const string ModelPattern = @"^[A-Z0-9-]+$";
		}

		public class Error
		{
			public const string UsernameLength = "{0} must be between 4 and 20 symbols long.";

			public const string UsernameAvailableSymbols = "{0} must contain only letters.";

			public const string PasswordLength = "The {0} must be at least {2} and at max {1} characters long.";

			public const string PasswordsMatch = "The password and confirmation password do not match.";

			public const string PasswordAvailableSymbols = "{0} must be at least 3 symbols long and contain only lowercase letters and digits.";

            public const string PasswordsRequired = "Password and current password are required!";

			public const string PhoneFormat = "{0} has to start with '+' sign followed by 10 to 12 digits.";

			public const string CameraPrice = "{0} must be positive number.";

			public const string CameraModelAvailableSymbols = "{0} can contain only uppercase letters, digits and dash.";

			public const string CameraModelLength = "{0} must be between 1 and 100 symbols long.";

			public const string ImageUrl = "{0} must start with http:// or https://";

			public const string MinIso = "{0} must be either 50 or 100.";

			public const string MaxIso = "{0} must be between 200 and 409600 and dividable by 100.";

			public const string VideoResolution = "{0} must be no longer than 15 characters.";

			public const string PasswordMissmatch = "Incorrect password!";

            public const string TwoFactorCode = "The {0} must be at least {2} and at max {1} characters long.";

            public const string NewPasswordAndConfirmPasswordMismatch = "The new password and confirmation password do not match.";
        }

		public class Display
		{
			public const string MaxShutterSpeed = "Max Shutter Speed";

			public const string MinShutterSpeed = "Min Shutter Speed";

			public const string MinIso = "Min ISO";

			public const string MaxIso = "Max ISO";

			public const string IsFullFrame = "Is Full Frame";

			public const string VideoResolution = "Video Resolution";

			public const string ImageUrl = "Image Url";

			public const string LightMetering = "Light Metering";

            public const string IsRestricted = "Is Restricted";

            public const string Email = "Email";

            public const string Password = "Password";

            public const string ConfirmPassword = "Confirm password";

            public const string ConfirmNewPassword = "Confirm new password";

            public const string CurrentPassword = "Current Password";

            public const string NewPassword = "New password";

            public const string RememberMe = "Remember me?";

            public const string AuthenticatorCode = "Authenticator code";

            public const string RememberThisMachine = "Remember this machine";

            public const string RecoveryCode = "Recovery Code";

            public const string PhoneNumber = "Phone number";
        }

		public class Message
		{
			public const string SuccessAddCamera = "Camera {0} {1} added successfully!";

			public const string SuccessDeletedCamera = "Camera deleted successfully!";

			public const string SuccessEditedCamera = "Camera {0} {1} edited successfully!";

			public const string UserAccessRestricted = "You don't have permission for adding camera. You have been restriced of adding cameras by administrator.";

			public const string NonExistingElement = "{0} with id {1} does not exist!";

			public const string NotCameraOwner = "You are not owner of that camera!";

			public const string NotProfileOwner = "You are not owner of that profile!";

			public const string ProfileEditedSuccessfully = "Profile edited successfully!";
		}

        public class Routing
        {
            public const string AdminAllUsers = "admin/users/all";

            public const string BaseCamerasRoute = "cameras";
            public const string AllCameras = "all";
            public const string AddCamera = "add";
            public const string CameraDetails = "details/{id}";
            public const string EditCamera = "edit/{id}";
            public const string DeleteCamera = "delete/{id}";

            public const string EditUserById = "{id}";
        }

        public class TempDataKey
        {
            public const string Message = "message";

            public const string AlertType = "alert-type";
        }

        public class Action
        {
            public const string Details = "Details";
        }

        public class Controller
        {
            public const string Account = "Account";
        }
    }
}
