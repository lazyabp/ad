using Lazy.Abp.Ad.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Ad.Admin
{
    public interface IAdvertisingItemManagementAppService :
        ICrudAppService<
            AdvertisingItemDto,
            Guid,
            AdvertisingItemListInput,
            AdvertisingItemCreateUpdateDto,
            AdvertisingItemCreateUpdateDto>
    {
        Task SetActive(Guid id, bool isActive);
    }
}
