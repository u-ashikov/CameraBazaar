namespace CameraBazaar.Web.Models.Cameras
{
    using Pagination;
    using Services.Models.Camera;
    using System.Collections.Generic;

    public class AllCamerasViewModel
    {
		public IEnumerable<CameraListingServiceModel> Cameras { get; set; }

		public PaginationViewModel Pagination { get; set; }
	}
}
