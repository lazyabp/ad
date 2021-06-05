using Lazy.Abp.Ad.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Ad.Admin
{
    [RemoteService(Name = AdAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("ad")]
    [ControllerName("Advertising")]
    [Route("api/ad/advertisings/management")]
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
        public Task<PagedResultDto<AdvertisingDto>> GetListAsync(AdvertisingListInput input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<AdvertisingDto> CreateAsync(AdvertisingCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<AdvertisingDto> UpdateAsync(Guid id, AdvertisingCreateUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/set-active/{isActive}")]
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
