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
    [ControllerName("UserAdvertising")]
    [Route("api/ad/user-advertisings")]
    public class UserAdvertisingsController : AdController, IUserAdvertisingAppService
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
        public Task<PagedResultDto<UserAdvertisingDto>> GetListAsync(UserAdvertisingListInput input)
        {
            return _userAdvertisingAppService.GetListAsync(input);
        }

        [HttpPost]
        public Task<UserAdvertisingDto> CreateAsync(UserAdvertisingCreateUpdateDto input)
        {
            return _userAdvertisingAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<UserAdvertisingDto> UpdateAsync(Guid id, UserAdvertisingCreateUpdateDto input)
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
