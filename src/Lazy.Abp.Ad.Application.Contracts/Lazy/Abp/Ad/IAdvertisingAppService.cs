using System;
using System.Threading.Tasks;
using Lazy.Abp.Ad.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Ad
{
    public interface IAdvertisingAppService : IApplicationService, ITransientDependency
    {
        Task<AdvertisingViewDto> GetAsync(Guid id);

        Task<AdvertisingViewDto> GetByNameAsync(string name);
    }
}