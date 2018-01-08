namespace CameraBazaar.Web.Models.Admin
{
    using Pagination;
    using Services.Models.User;
    using System.Collections.Generic;

    public class AllUsersViewModel
    {
		public IEnumerable<UserListingServiceModel> Users { get; set; }

		public PaginationViewModel Pagination { get; set; }
    }
}
