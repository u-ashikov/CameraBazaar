namespace CameraBazaar.Services.Contracts
{
    using Data.Enums;
    using Models.Camera;
    using System.Collections.Generic;

    public interface ICameraService 
    {
        IEnumerable<CameraListingServiceModel> All(int page = 1, int pageSize = 5);

        void Add(Make make, string model, decimal price, int quantity, int minShutterSpeed, int maxShutterSpeed, int minIso, int maxIso, bool isFullFrame, string videoResolution, IEnumerable<LightMetering> lightMeterings, string description, string imageUrl, string userId);

		void Edit(int id, Make make, string model, decimal price, int quantity, int minShutterSpeed, int maxShutterSpeed, int minIso, int maxIso, bool isFullFrame, string videoResolution, IEnumerable<LightMetering> lightMeterings, string description, string imageUrl);

		CameraEditServiceModel GetCameraToEdit(int id);

        void Delete(int id);

        CameraDetailsServiceModel Details(int id);

		bool CameraExists(int id);

		bool IsOwner(int cameraId, string userId);

		int TotalCameras();
    }
}
