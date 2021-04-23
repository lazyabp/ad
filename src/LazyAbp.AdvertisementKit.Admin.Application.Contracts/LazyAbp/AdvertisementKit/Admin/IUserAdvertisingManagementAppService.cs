using LazyAbp.AdvertisementKit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.AdvertisementKit.Admin
{
    public interface IUserAdvertisingManagementAppService : IApplicationService, ITransientDependency
    {
        Task<UserAdvertisingDto> GetAsync(Guid id);

        Task<PagedResultDto<UserAdvertisingDto>> GetListAsync(GetUserAdvertisingListInput input);
    }
}
