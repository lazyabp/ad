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
    [ControllerName("UserAdvertising")]
    [Route("api/advertisementkit/user-advertisings/admin")]
    public class UserAdvertisingManagementController : AbpController, IUserAdvertisingManagementAppService
    {
        private readonly IUserAdvertisingManagementAppService _service;

        public UserAdvertisingManagementController(IUserAdvertisingManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<UserAdvertisingDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<UserAdvertisingDto>> GetListAsync(GetUserAdvertisingListInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}
