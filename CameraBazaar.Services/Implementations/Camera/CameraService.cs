namespace CameraBazaar.Services.Implementations.Camera
{
    using AutoMapper;
    using Contracts;
    using Data;
    using Data.Enums;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Camera;
    using System.Collections.Generic;
    using System.Linq;

    public class CameraService : ICameraService
	{
		private readonly CameraBazaarDbContext db;

		private readonly IMapper mapper;

		public CameraService(CameraBazaarDbContext db, IMapper mapper)
		{
			this.db = db;
			this.mapper = mapper;
		}

		public void Add(Make make, string model, decimal price, int quantity, int minShutterSpeed, int maxShutterSpeed, int minIso, int maxIso, bool isFullFrame, string videoResolution, IEnumerable<LightMetering> lightMeterings, string description, string imageUrl, string userId)
		{
			var lightMetering = (LightMetering)lightMeterings.Sum(lm => (int)lm);

			var camera = new Camera
			{
				Make = make,
				Model = model,
				Price = price,
				Quantity = quantity,
				MinShutterSpeed = minShutterSpeed,
				MaxShutterSpeed = maxShutterSpeed,
				MinIso = minIso,
				MaxIso = maxIso,
				IsFullFrame = isFullFrame,
				VideoResolution = videoResolution,
				LightMetering = (LightMetering)lightMeterings.Sum(lm => (int)lm),
				Description = description,
				ImageUrl = imageUrl,
				UserId = userId
			};

			this.db.Cameras.Add(camera);
			this.db.SaveChanges();
		}

		public IEnumerable<CameraListingServiceModel> All(int page = 1, int pageSize = 5) => 
			this.mapper
				.Map<IEnumerable<CameraListingServiceModel>>(
					this.db
						.Cameras
						.OrderByDescending(c => c.Id)
						.Skip((page-1)*pageSize)
						.Take(pageSize)
						.Include(c=>c.User));

		public CameraDetailsServiceModel Details(int id) =>
			this.mapper.Map<CameraDetailsServiceModel>(
				this.db.Cameras
					.Include(c=>c.User)
					.FirstOrDefault(c => c.Id == id));

		public CameraEditServiceModel GetCameraToEdit(int id) =>
			this.mapper
				.Map<CameraEditServiceModel>(
					this.db
						.Cameras.Find(id));

		public void Edit(int id,Make make, string model, decimal price, int quantity, int minShutterSpeed, int maxShutterSpeed, int minIso, int maxIso, bool isFullFrame, string videoResolution, IEnumerable<LightMetering> lightMeterings, string description, string imageUrl)
		{
			var cameraToEdit = this.db.Cameras.Find(id);

			if (cameraToEdit == null)
			{
				return;
			}

			cameraToEdit.Make = make;
			cameraToEdit.Model = model;
			cameraToEdit.Price = price;
			cameraToEdit.Quantity = quantity;
			cameraToEdit.MinShutterSpeed = minShutterSpeed;
			cameraToEdit.MaxShutterSpeed = maxShutterSpeed;
			cameraToEdit.MinIso = minIso;
			cameraToEdit.MaxIso = maxIso;
			cameraToEdit.IsFullFrame = isFullFrame;
			cameraToEdit.VideoResolution = videoResolution;
			cameraToEdit.LightMetering = (LightMetering)lightMeterings.Sum(lm => (int)lm);
			cameraToEdit.Description = description;
			cameraToEdit.ImageUrl = imageUrl;

			this.db.SaveChanges();
		}

		public bool CameraExists(int id) => this.db.Cameras.Any(c => c.Id == id);

		public bool IsOwner(int cameraId, string userId) => this.db.Users
			.Include(u=>u.Cameras)
				.FirstOrDefault(u => u.Id == userId)
				.Cameras.Any(c => c.Id == cameraId);

		public void Delete(int id)
		{
			var cameraToDelete = this.db.Cameras.Find(id);

			this.db.Cameras.Remove(cameraToDelete);
			this.db.SaveChanges();
		}

		public int TotalCameras() => this.db.Cameras.Count();
	}
}
