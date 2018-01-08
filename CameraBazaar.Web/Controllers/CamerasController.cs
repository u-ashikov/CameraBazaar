namespace CameraBazaar.Web.Controllers
{
    using Common;
    using Data.Enums;
    using Data.Models;
    using Infrastructure.Enums;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Cameras;
    using Models.Pagination;
    using Services.Contracts;
    using System;
    using System.Linq;

    using static Common.CameraBazaarConstants.Routing;

    [Authorize]
	[Route(BaseCamerasRoute)]
	public class CamerasController : BaseController
    {
		private readonly ICameraService cameras;

		private readonly IUserService users;

		private readonly UserManager<User> userManager;

		public CamerasController(ICameraService cameras, UserManager<User> userManager, IUserService users)
		{
			this.cameras = cameras;
			this.userManager = userManager;
			this.users = users;
		}

		[Route(AddCamera)]
		public IActionResult Add()
		{
			if (this.users.IsRestricted(this.userManager.GetUserId(User)))
			{
				this.GenerateOperationMessage(CameraBazaarConstants.Message.UserAccessRestricted, Alert.Danger);
				return RedirectToAction(nameof(All));
			}

			return View();
		}

		[HttpPost(AddCamera)]
		[ValidateAntiForgeryToken]
		public IActionResult Add(CameraFormModel camera)
		{
			if (!ModelState.IsValid)
			{
				return View(camera);
			}

			this.cameras.Add(
				camera.Make, 
				camera.Model, 
				camera.Price, 
				camera.Quantity, 
				camera.MinShutterSpeed, 
				camera.MaxShutterSpeed, 
				camera.MinIso, 
				camera.MaxIso, 
				camera.IsFullFrame, 
				camera.VideoResolution, 
				camera.LightMeterings,
				camera.Description, 
				camera.ImageUrl,
				this.userManager.GetUserId(HttpContext.User));

			this.GenerateOperationMessage(string.Format(CameraBazaarConstants.Message.SuccessAddCamera, camera.Make, camera.Model), Alert.Success);

			return RedirectToAction(nameof(All));
		}

		[Route(AllCameras)]
		[AllowAnonymous]
		public IActionResult All(int page = 1)
		{
			if (page < CameraBazaarConstants.MinPageSize)
			{
				return Redirect(this.Url.Action(nameof(All),new {page = CameraBazaarConstants.MinPageSize }));
			}

			var cameras = this.cameras.All(page, CameraBazaarConstants.Camera.PageSize);

            var pages = (int)Math.Ceiling(this.cameras.TotalCameras() / (double)CameraBazaarConstants.Camera.PageSize);

            if (page > pages && pages != 0)
            {
                return Redirect(this.Url.Action(nameof(All), new { page = pages }));
            }

            var allCameras = new AllCamerasViewModel()
			{
				Cameras = cameras,
				Pagination = new PaginationViewModel()
				{
					CurrentPage = page,
					TotalPages = pages
				}
			};

			return View(allCameras);
		}

        [AllowAnonymous]
        [Route(CameraDetails)]
		public IActionResult Details(int id)
		{
			if (!this.cameras.CameraExists(id))
			{
				return this.NonExistingElement(id.ToString(),nameof(All));
			}

			return View(this.cameras.Details(id));
		}

		[HttpGet(EditCamera)]
		public IActionResult Edit(int id)
		{
			if (!this.cameras.CameraExists(id))
			{
				return this.NonExistingElement(id.ToString(), nameof(All));
			}

			var userId = this.userManager.GetUserId(HttpContext.User);

			if (!this.cameras.IsOwner(id,this.userManager.GetUserId(HttpContext.User)))
			{
				this.NotCameraOwner();
				return RedirectToAction(nameof(All));
			}

			var camera = this.cameras.GetCameraToEdit(id);

			return View(new CameraFormModel()
			{
				Make = camera.Make,
				Model = camera.Model,
				Description = camera.Description,
				ImageUrl = camera.ImageUrl,
				IsFullFrame = camera.IsFullFrame,
				LightMeterings = Convert.ToString(camera.LightMetering).Split(new char[] {' ',','},StringSplitOptions.RemoveEmptyEntries)
				.Select(l=>(LightMetering)Enum.Parse(typeof(LightMetering),l)),
				MaxIso = camera.MaxIso,
				MinIso = camera.MinIso,
				MaxShutterSpeed = camera.MaxShutterSpeed,
				MinShutterSpeed = camera.MinShutterSpeed,
				Price = camera.Price,
				Quantity = camera.Quantity,
				VideoResolution = camera.VideoResolution
			});
		}

		[HttpPost(EditCamera)]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id,CameraFormModel camera)
		{
			if (!this.cameras.IsOwner(id, this.userManager.GetUserId(HttpContext.User)))
			{
				this.NotCameraOwner();
				return RedirectToAction(nameof(All));
			}

			if (!ModelState.IsValid)
			{
				return View(camera);
			}

			this.cameras.Edit(id, camera.Make, camera.Model, camera.Price, camera.Quantity, camera.MinShutterSpeed, camera.MaxShutterSpeed, camera.MinIso, camera.MaxIso, camera.IsFullFrame, camera.VideoResolution, camera.LightMeterings, camera.Description, camera.ImageUrl);

			this.GenerateOperationMessage(string.Format(CameraBazaarConstants.Message.SuccessEditedCamera, camera.Make, camera.Model), Alert.Success);

			return RedirectToAction(nameof(All));
		}

		[Route(DeleteCamera)]
		public IActionResult Delete(int id, string seller)
		{
			if (!this.cameras.IsOwner(id, this.userManager.GetUserId(HttpContext.User)))
			{
				this.NotCameraOwner();
				return RedirectToAction(nameof(All));
			}

			if (!this.cameras.CameraExists(id))
			{
				return this.NonExistingElement(id.ToString(), nameof(All));
			}

			this.cameras.Delete(id);
			var userId = this.users.GetUserId(seller);

			this.GenerateOperationMessage(CameraBazaarConstants.Message.SuccessDeletedCamera, Alert.Success);

			return RedirectToAction(CameraBazaarConstants.Action.Details, CameraBazaarConstants.Controller.Account, new { id = userId });
		}

		private void NotCameraOwner()
		{
			this.GenerateOperationMessage(CameraBazaarConstants.Message.NotCameraOwner, Alert.Danger);
		}
    }
}
