using System;
using System.Threading.Tasks;
using LazyAbp.AdvertisementKit.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.AdvertisementKit
{
    public interface IAdvertisingAppService : IApplicationService, ITransientDependency
    {
        Task<AdvertisingViewDto> GetAsync(Guid id);

        Task<AdvertisingViewDto> GetByNameAsync(string name);
    }
}