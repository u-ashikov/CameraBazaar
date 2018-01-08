namespace CameraBazaar.Infrastructure.Automapper.Profiles
{
    using AutoMapper;
    using Data.Models;
    using Services.Models.Camera;
    using System;

    public class CameraMappingProfile : Profile
    {
		public CameraMappingProfile()
		{
			CreateMap<Camera, CameraEditServiceModel>();

			CreateMap<Camera, CameraListingServiceModel>()
				.ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make.ToString()))
				.ForMember(dest => dest.InStock, opt => opt.MapFrom(src => src.Quantity > 0 ? true : false))
				.ForMember(dest => dest.Seller, opt => opt.MapFrom(src => src.User.UserName));

			CreateMap<Camera, CameraDetailsServiceModel>()
				.ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make.ToString()))
				.ForMember(dest => dest.InStock, opt => opt.MapFrom(src => src.Quantity > 0 ? true : false))
				.ForMember(dest => dest.IsFullFrame, opt => opt.MapFrom(src => src.IsFullFrame ? "Yes" : "No"))
				.ForMember(dest => dest.LightMeterings, opt => opt.MapFrom(src => Convert.ToString(src.LightMetering)
				.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)))
				.ForMember(dest => dest.Seller, opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(dest => dest.SellerId, opt => opt.MapFrom(src => src.UserId));
		}
    }
}
