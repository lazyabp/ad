using Lazy.Abp.Ad.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Ad.Admin
{
    public interface IUserAdvertisingManagementAppService : IApplicationService, ITransientDependency
    {
        Task<UserAdvertisingDto> GetAsync(Guid id);

        Task<PagedResultDto<UserAdvertisingDto>> GetListAsync(UserAdvertisingListInput input);
    }
}
