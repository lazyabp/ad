using Lazy.Abp.Ad.Dtos;
using AutoMapper;

namespace Lazy.Abp.Ad
{
    public class AdApplicationAutoMapperProfile : Profile
    {
        public AdApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
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
