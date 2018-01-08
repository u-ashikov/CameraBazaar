namespace CameraBazaar.Services.Contracts
{
    using Microsoft.AspNetCore.Identity;
    using Models.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
		bool UserExist(string id);

		SellerDetailsServiceModel SellerDetails(string id, int page, int pageSize = 10);

		UserEditServiceModel GetUserToEdit(string id);

		string GetUserId(string username);

		Task<IEnumerable<IdentityError>> Edit(string id, string email, string password,string currentPassword, string phone);

		bool PasswordMatch(string userId, string password);

		void RecordLoginTime(string username);

		int UserTotalCameras(string id);

		IEnumerable<UserListingServiceModel> All(int page, int pageSize);

		void ChangePermission(string id);

		bool IsRestricted(string id);

		int TotalUsers();
    }
}
