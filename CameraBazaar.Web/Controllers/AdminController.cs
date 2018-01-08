namespace CameraBazaar.Web.Controllers
{
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Admin;
    using Models.Pagination;
    using Services.Contracts;
    using System;

    using static Common.CameraBazaarConstants.Routing;

    [Authorize(Roles = CameraBazaarConstants.AdministratorRole)]
	public class AdminController : Controller
    {
		private readonly IUserService users;

		public AdminController(IUserService users)
		{
			this.users = users;
		}

		[Route(AdminAllUsers)]
		public IActionResult AllUsers(int page = 1)
		{
			var totalPages = (int)Math.Ceiling(this.users.TotalUsers() / (double)CameraBazaarConstants.User.PageSize);

			if (page < CameraBazaarConstants.MinPageSize || page > totalPages)
			{
				return Redirect(this.Url.Action(nameof(AllUsers), new { page = CameraBazaarConstants.MinPageSize }));
			}

			var users = new AllUsersViewModel()
			{
				Users = this.users.All(page, CameraBazaarConstants.User.PageSize),
				Pagination = new PaginationViewModel()
				{
					CurrentPage = page,
					TotalPages = totalPages
				}
			};

			return View(users);
		}

		public IActionResult ChangePermission(string id)
		{
			if (!this.users.UserExist(id))
			{
				return NotFound();
			}

			this.users.ChangePermission(id);

			return RedirectToAction(nameof(AllUsers));
		}
    }
}
