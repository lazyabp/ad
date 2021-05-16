using AutoMapper;
using Lazy.Abp.Ad.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Ad.Admin
{
    public class AdAdminApplicationAutoMapperProfile : Profile
    {
        public AdAdminApplicationAutoMapperProfile()
        {
            CreateMap<Advertising, AdvertisingDto>();
            CreateMap<Advertising, AdvertisingViewDto>();
            CreateMap<AdvertisingCreateUpdateDto, Advertising>(MemberList.Source);
            CreateMap<AdvertisingItem, AdvertisingItemDto>();
            CreateMap<AdvertisingItem, AdvertisingItemViewDto>();
            CreateMap<AdvertisingItem, UserAdvertisingItemCreateUpdateDto>()
                .ForMember(m => m.AdvertisingItemId, op => op.MapFrom(s => s.Id));
            CreateMap<AdvertisingItemDto, UserAdvertisingItemCreateUpdateDto>()
                .ForMember(m => m.AdvertisingItemId, op => op.MapFrom(s => s.Id));
            CreateMap<AdvertisingItemCreateUpdateDto, AdvertisingItem>(MemberList.Source);
            CreateMap<UserAdvertising, UserAdvertisingDto>()
                .ForMember(q => q.AdvertisingItem, op => op.Ignore());
        }
    }
}
