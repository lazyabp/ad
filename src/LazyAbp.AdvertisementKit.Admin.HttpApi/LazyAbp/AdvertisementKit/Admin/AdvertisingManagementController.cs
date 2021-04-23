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
    [ControllerName("Advertising")]
    [Route("api/advertisementkit/advertisings/admin")]
    public class AdvertisingManagementController : AbpController, IAdvertisingManagementAppService
    {
        private readonly IAdvertisingManagementAppService _service;

        public AdvertisingManagementController(IAdvertisingManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<AdvertisingDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<AdvertisingDto>> GetListAsync(GetAdvertisingListInput input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<AdvertisingDto> CreateAsync(CreateUpdateAdvertisingDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<AdvertisingDto> UpdateAsync(Guid id, CreateUpdateAdvertisingDto input)
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
