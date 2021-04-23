using LazyAbp.AdvertisementKit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LazyAbp.AdvertisementKit.Admin
{
    public interface IAdvertisingManagementAppService :
        ICrudAppService<
            AdvertisingDto,
            Guid,
            GetAdvertisingListInput,
            CreateUpdateAdvertisingDto,
            CreateUpdateAdvertisingDto>
    {
        Task SetActive(Guid id, bool isActive);
    }
}
