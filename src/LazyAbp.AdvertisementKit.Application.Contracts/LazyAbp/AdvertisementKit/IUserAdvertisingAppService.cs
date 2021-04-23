using System;
using System.Threading.Tasks;
using LazyAbp.AdvertisementKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.AdvertisementKit
{
    public interface IUserAdvertisingAppService :
        ICrudAppService< 
            UserAdvertisingDto, 
            Guid,
            GetUserAdvertisingListInput,
            CreateUpdateUserAdvertisingDto,
            CreateUpdateUserAdvertisingDto>
    {
        
    }
}