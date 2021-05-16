using Lazy.Abp.Ad.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Ad
{
    [RemoteService(Name = AdRemoteServiceConsts.RemoteServiceName)]
    [Area("ad")]
    [ControllerName("Advertising")]
    [Route("api/ad/advertisings")]
    public class AdvertisingsController : AdController, IAdvertisingAppService
    {
        private readonly IAdvertisingAppService _advertisingAppService;

        public AdvertisingsController(IAdvertisingAppService advertisingAppService)
        {
            _advertisingAppService = advertisingAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<AdvertisingViewDto> GetAsync(Guid id)
        {
            return _advertisingAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("by-name/{name}")]
        public async Task<AdvertisingViewDto> GetByNameAsync(string name)
        {
            return await _advertisingAppService.GetByNameAsync(name);
        }
    }
}
