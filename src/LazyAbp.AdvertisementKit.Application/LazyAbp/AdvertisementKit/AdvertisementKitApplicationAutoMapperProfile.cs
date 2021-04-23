using LazyAbp.AdvertisementKit.Dtos;
using AutoMapper;

namespace LazyAbp.AdvertisementKit
{
    public class AdvertisementKitApplicationAutoMapperProfile : Profile
    {
        public AdvertisementKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Advertising, AdvertisingDto>();
            CreateMap<Advertising, AdvertisingViewDto>();
            CreateMap<CreateUpdateAdvertisingDto, Advertising>(MemberList.Source);
            CreateMap<AdvertisingItem, AdvertisingItemDto>();
            CreateMap<AdvertisingItem, AdvertisingItemViewDto>();
            CreateMap<AdvertisingItem, CreateUpdateUserAdvertisingItemDto>()
                .ForMember(m => m.AdvertisingItemId, op => op.MapFrom(s => s.Id));
            CreateMap<AdvertisingItemDto, CreateUpdateUserAdvertisingItemDto>()
                .ForMember(m => m.AdvertisingItemId, op => op.MapFrom(s => s.Id));
            CreateMap<CreateUpdateAdvertisingItemDto, AdvertisingItem>(MemberList.Source);
            CreateMap<UserAdvertising, UserAdvertisingDto>()
                .ForMember(q => q.AdvertisingItem, op => op.Ignore());
        }
    }
}
