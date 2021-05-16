using Lazy.Abp.Ad.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Ad.Admin
{
    public interface IAdvertisingManagementAppService :
        ICrudAppService<
            AdvertisingDto,
            Guid,
            AdvertisingListInput,
            AdvertisingCreateUpdateDto,
            AdvertisingCreateUpdateDto>
    {
        Task SetActive(Guid id, bool isActive);
    }
}
