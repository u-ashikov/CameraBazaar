namespace CameraBazaar.Services.Implementations.User
{
    using AutoMapper;
    using Common;
    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
	{
		private readonly CameraBazaarDbContext db;

		private readonly UserManager<User> userManager;

		private readonly IMapper mapper;

		public UserService(CameraBazaarDbContext db, IMapper mapper, UserManager<User> userManager)
		{
			this.db = db;
			this.mapper = mapper;
			this.userManager = userManager;
		}

		public SellerDetailsServiceModel SellerDetails(string id, int page, int pageSize = 10)
		{
			var userInfo = this.db.Users
				.Include(u=>u.Cameras)
				.FirstOrDefault(u => u.Id == id);

			userInfo.Cameras = userInfo.Cameras
				.OrderByDescending(c=>c.Id)
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			var result = this.mapper.Map<SellerDetailsServiceModel>(userInfo);

			result.CamerasInStock = this.db.Cameras.Count(c => c.UserId == id && c.Quantity > 0);
			result.CamerasOutOfStock = this.db.Cameras.Count(c => c.UserId == id && c.Quantity == 0);

			return result;
		}
			

		public bool UserExist(string id) => this.db.Users.Any(u => u.Id == id);

		public UserEditServiceModel GetUserToEdit(string id) =>
			this.mapper.Map<UserEditServiceModel>(
				this.db
					.Users.Find(id));

		public string GetUserId(string username) => this.db.Users.FirstOrDefault(u => u.UserName == username).Id;

		public bool PasswordMatch(string userId, string password) => this.db.Users.Find(userId).PasswordHash == password;

		public async Task<IEnumerable<IdentityError>> Edit(string id, string email, string password,string currentPassword, string phone)
		{
			var userToEdit = await this.userManager.FindByIdAsync(id);
			var errors = new HashSet<IdentityError>();

			var emailToken = await this.userManager.GenerateChangeEmailTokenAsync(userToEdit,email);
			var emailChanged = await this.userManager.ChangeEmailAsync(userToEdit, email, emailToken);

			if (!emailChanged.Succeeded)
			{
				this.AddError(errors, emailChanged);
			}

			if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(currentPassword))
			{
				var passwordChanged = await this.userManager.ChangePasswordAsync(userToEdit, currentPassword, password);

				if (!passwordChanged.Succeeded)
				{
					this.AddError(errors, passwordChanged);
				}
			}
            else if ((string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(currentPassword)) 
                || (!string.IsNullOrEmpty(password) && string.IsNullOrEmpty(currentPassword)))
            {
                errors.Add(new IdentityError()
                {
                    Description = CameraBazaarConstants.Error.PasswordsRequired
                });
            }

			var phoneToken = await this.userManager.GenerateChangePhoneNumberTokenAsync(userToEdit, phone);

			var phoneChanged = await this.userManager.ChangePhoneNumberAsync(userToEdit, phone, phoneToken);

			if (!phoneChanged.Succeeded)
			{
				this.AddError(errors, phoneChanged);
			}

			return errors;
		}

		public void RecordLoginTime(string username)
		{
			var user = this.db.Users.FirstOrDefault(u => u.UserName == username);

			if (user.FirstLoginTime == null)
			{
				user.FirstLoginTime = DateTime.UtcNow;
			}
			else
			{
				user.LastLoginTime = DateTime.UtcNow;
			}

			this.db.SaveChanges();
		}

		public int UserTotalCameras(string id) => this.db.Users.Include(u=>u.Cameras).FirstOrDefault(u=>u.Id == id)
			.Cameras.Count;

		public IEnumerable<UserListingServiceModel> All(int page, int pageSize = 10) => this.mapper.Map<IEnumerable<UserListingServiceModel>>(
			this.db.Users
				.Skip((page-1)*pageSize)
				.Take(pageSize)
				.Where(u => u.UserName != CameraBazaarConstants.AdminUserName)
				.ToList());

		public int TotalUsers() => this.db.Users.Count();

		public void ChangePermission(string id)
		{
			var user = this.db.Users.Find(id);

			if (user.IsRestricted)
			{
				user.IsRestricted = false;
			}
			else
			{
				user.IsRestricted = true;
			}

			this.db.SaveChanges();
		}

		public bool IsRestricted(string id) => this.db.Users.Find(id).IsRestricted;

		private void AddError(HashSet<IdentityError> errors, IdentityResult identityResult)
		{
			foreach (var e in identityResult.Errors)
			{
				errors.Add(e);
			}
		}
	}
}
