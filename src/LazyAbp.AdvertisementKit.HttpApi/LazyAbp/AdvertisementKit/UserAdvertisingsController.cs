using LazyAbp.AdvertisementKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.AdvertisementKit
{
    [RemoteService(Name = AdvertisementKitRemoteServiceConsts.RemoteServiceName)]
    [Area("advertisementkit")]
    [ControllerName("UserAdvertising")]
    [Route("api/advertisementkit/user-advertisings")]
    public class UserAdvertisingsController : AdvertisementKitController, IUserAdvertisingAppService
    {
        private readonly IUserAdvertisingAppService _userAdvertisingAppService;

        public UserAdvertisingsController(IUserAdvertisingAppService userAdvertisingAppService)
        {
            _userAdvertisingAppService = userAdvertisingAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<UserAdvertisingDto> GetAsync(Guid id)
        {
            return _userAdvertisingAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<UserAdvertisingDto>> GetListAsync(GetUserAdvertisingListInput input)
        {
            return _userAdvertisingAppService.GetListAsync(input);
        }

        [HttpPost]
        public Task<UserAdvertisingDto> CreateAsync(CreateUpdateUserAdvertisingDto input)
        {
            return _userAdvertisingAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<UserAdvertisingDto> UpdateAsync(Guid id, CreateUpdateUserAdvertisingDto input)
        {
            return _userAdvertisingAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _userAdvertisingAppService.DeleteAsync(id);
        }
    }
}
