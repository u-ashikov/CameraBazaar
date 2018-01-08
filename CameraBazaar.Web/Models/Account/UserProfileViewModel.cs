namespace CameraBazaar.Web.Models.Account
{
    using Pagination;
    using Services.Models.User;

    public class UserProfileViewModel
    {
		public SellerDetailsServiceModel Profile { get; set; }

		public PaginationViewModel Pagination { get; set; }
    }
}
