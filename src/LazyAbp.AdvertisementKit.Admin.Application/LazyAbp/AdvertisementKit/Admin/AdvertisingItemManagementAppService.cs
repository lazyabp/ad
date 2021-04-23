﻿using LazyAbp.AdvertisementKit.Admin.Permissions;
using LazyAbp.AdvertisementKit.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.AdvertisementKit.Admin
{
    public class AdvertisingItemManagementAppService : CrudAppService<AdvertisingItem, AdvertisingItemDto, Guid, GetAdvertisingItemListInput, CreateUpdateAdvertisingItemDto, CreateUpdateAdvertisingItemDto>,
        IAdvertisingItemManagementAppService
    {
        protected override string GetPolicyName { get; set; } = AdvertisementKitAdminPermissions.AdvertisingItem.Default;
        protected override string GetListPolicyName { get; set; } = AdvertisementKitAdminPermissions.AdvertisingItem.Default;
        protected override string CreatePolicyName { get; set; } = AdvertisementKitAdminPermissions.AdvertisingItem.Create;
        protected override string UpdatePolicyName { get; set; } = AdvertisementKitAdminPermissions.AdvertisingItem.Update;
        protected override string DeletePolicyName { get; set; } = AdvertisementKitAdminPermissions.AdvertisingItem.Delete;

        private readonly IAdvertisingItemRepository _repository;

        public AdvertisingItemManagementAppService(IAdvertisingItemRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async override Task<PagedResultDto<AdvertisingItemDto>> GetListAsync(GetAdvertisingItemListInput input)
        {
            var totalCount = await _repository.GetCountAsync(input.AdvertisingId, input.IsActive, input.IsOnSale, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.AdvertisingId, input.IsActive, input.IsOnSale, input.Filter);

            return new PagedResultDto<AdvertisingItemDto>(
                    totalCount,
                    ObjectMapper.Map<List<AdvertisingItem>, List<AdvertisingItemDto>>(list)
                );
        }

        [Authorize(AdvertisementKitAdminPermissions.AdvertisingItem.Update)]
        public async Task SetActive(Guid id, bool isActive)
        {
            var advertising = await _repository.GetAsync(id);
            advertising.SetActive(isActive);
        }
    }
}
