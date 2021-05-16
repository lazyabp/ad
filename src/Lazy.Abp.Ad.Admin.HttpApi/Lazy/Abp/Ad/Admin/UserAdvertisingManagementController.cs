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
    [ControllerName("UserAdvertising")]
    [Route("api/ad/user-advertisings/management")]
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
        public Task<PagedResultDto<UserAdvertisingDto>> GetListAsync(UserAdvertisingListInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}
