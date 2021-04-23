using System;
using LazyAbp.AdvertisementKit.Permissions;
using LazyAbp.AdvertisementKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace LazyAbp.AdvertisementKit
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
