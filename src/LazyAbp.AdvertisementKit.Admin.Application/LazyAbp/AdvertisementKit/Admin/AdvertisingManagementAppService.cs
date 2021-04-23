using LazyAbp.AdvertisementKit.Admin.Permissions;
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
    public class AdvertisingManagementAppService : CrudAppService<Advertising, AdvertisingDto, Guid, GetAdvertisingListInput, CreateUpdateAdvertisingDto, CreateUpdateAdvertisingDto>,
        IAdvertisingManagementAppService
    {
        protected override string GetPolicyName { get; set; } = AdvertisementKitAdminPermissions.Advertising.Default;
        protected override string GetListPolicyName { get; set; } = AdvertisementKitAdminPermissions.Advertising.Default;
        protected override string CreatePolicyName { get; set; } = AdvertisementKitAdminPermissions.Advertising.Create;
        protected override string UpdatePolicyName { get; set; } = AdvertisementKitAdminPermissions.Advertising.Update;
        protected override string DeletePolicyName { get; set; } = AdvertisementKitAdminPermissions.Advertising.Delete;

        private readonly IAdvertisingRepository _repository;

        public AdvertisingManagementAppService(IAdvertisingRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async override Task<PagedResultDto<AdvertisingDto>> GetListAsync(GetAdvertisingListInput input)
        {
            var totalCount = await _repository.GetCountAsync(input.AdvertisementType, input.IsActive, input.Filter);
            var advertisings = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.AdvertisementType, input.IsActive, input.Filter, input.includeDetails);

            return new PagedResultDto<AdvertisingDto>(
                    totalCount,
                    ObjectMapper.Map<List<Advertising>, List<AdvertisingDto>>(advertisings)
                );
        }

        [Authorize(AdvertisementKitAdminPermissions.Advertising.Update)]
        public async Task SetActive(Guid id, bool isActive)
        {
            var advertising = await _repository.GetAsync(id);
            advertising.SetActive(isActive);
        }

        public async override Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
