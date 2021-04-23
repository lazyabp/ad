using LazyAbp.AdvertisementKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.AdvertisementKit.Admin
{
    [RemoteService(Name = AdvertisementKitAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("advertisementkitadmin")]
    [ControllerName("AdvertisingItem")]
    [Route("api/advertisementkit/advertising-items/admin")]
    public class AdvertisingItemManagementController : AbpController, IAdvertisingItemManagementAppService
    {
        private readonly IAdvertisingItemManagementAppService _service;

        public AdvertisingItemManagementController(IAdvertisingItemManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<AdvertisingItemDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<AdvertisingItemDto>> GetListAsync(GetAdvertisingItemListInput input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<AdvertisingItemDto> CreateAsync(CreateUpdateAdvertisingItemDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<AdvertisingItemDto> UpdateAsync(Guid id, CreateUpdateAdvertisingItemDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/set-active")]
        public Task SetActive(Guid id, bool isActive)
        {
            return _service.SetActive(id, isActive);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
