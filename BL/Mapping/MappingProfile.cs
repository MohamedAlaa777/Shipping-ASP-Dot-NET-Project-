using AutoMapper;
using BL.Dtos;
using DAL.Entities;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.Mapping
{
    public class MappingProfile : Profile
    {
        // configurations of automapper
        public MappingProfile() 
        {
        // ReverseMap() is for source to distination & distination to source (reverse) allows for two way mapping
            CreateMap<TbCarrier,CarrierDto>().ReverseMap();
            CreateMap<TbCity, CityDto>().ReverseMap();
            CreateMap<VwCities, CityDto>().ReverseMap();
            CreateMap<TbCountry, CountryDto>().ReverseMap();
            CreateMap<TbRefreshTokens, RefreshTokenDto>().ReverseMap();
            CreateMap<TbPaymentMethod, PaymentMethodDto>().ReverseMap();
            CreateMap<TbSetting, SettingDto>().ReverseMap();
            CreateMap<TbShippingType, ShippingTypeDto>().ReverseMap();
            CreateMap<TbShippment, ShippmentDto>().ReverseMap();
            CreateMap<TbShipmentStatus, ShippmentStatusDto>().ReverseMap();
            CreateMap<TbSubscriptionPackage, SubscriptionPackageDto>().ReverseMap();
            CreateMap<TbUserSebder, UserSenderDto>().ReverseMap();
            CreateMap<TbUserReceiver, UserReceiverDto>().ReverseMap();
            CreateMap<TbUserSubscription, UserSubscriptionDto>().ReverseMap();
            CreateMap<TbShipingPackging, ShipingPackgingDto>().ReverseMap();
        }
    }
}
