namespace CameraBazaar.Infrastructure.Automapper.Profiles
{
    using AutoMapper;
    using Data.Models;
    using Services.Models.Camera;
    using Services.Models.User;
    using System.Linq;

    public class UserMappingProfile : Profile
    {
		public UserMappingProfile()
		{
			CreateMap<User, UserEditServiceModel>();

			CreateMap<User, UserListingServiceModel>();

			CreateMap<User, SellerDetailsServiceModel>()
				.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber == null ? "None" : src.PhoneNumber))
				.ForMember(dest => dest.Cameras, opt => opt.MapFrom(src => src.Cameras.Select(c=> new CameraListingServiceModel()
				{
					Id = c.Id,
					ImageUrl = c.ImageUrl,
					InStock = c.Quantity > 0 ? true : false,
					Make = c.Make.ToString(),
					Model = c.Model,
					Price = c.Price,
					Seller = c.User.UserName
				})));
		}
    }
}
