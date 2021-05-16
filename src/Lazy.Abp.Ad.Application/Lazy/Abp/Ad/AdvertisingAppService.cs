using System;
using Lazy.Abp.Ad.Permissions;
using Lazy.Abp.Ad.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace Lazy.Abp.Ad
{
    public class AdvertisingAppService : ApplicationService, IAdvertisingAppService
    {
        private readonly IAdvertisingRepository _repository;
        
        public AdvertisingAppService(IAdvertisingRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        public async Task<AdvertisingViewDto> GetAsync(Guid id)
        {
            var advertising = await _repository.FindByIdAsync(id);

            return ObjectMapper.Map<Advertising, AdvertisingViewDto>(advertising);
        }

        [AllowAnonymous]
        public async Task<AdvertisingViewDto> GetByNameAsync(string name)
        {
            var advertising = await _repository.FindByNameAsync(name);

            return ObjectMapper.Map<Advertising, AdvertisingViewDto>(advertising);
        }
    }
}
