using System;
using System.Threading.Tasks;
using Lazy.Abp.Ad.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Ad
{
    public interface IUserAdvertisingAppService :
        ICrudAppService< 
            UserAdvertisingDto, 
            Guid,
            UserAdvertisingListInput,
            UserAdvertisingCreateUpdateDto,
            UserAdvertisingCreateUpdateDto>
    {
        
    }
}