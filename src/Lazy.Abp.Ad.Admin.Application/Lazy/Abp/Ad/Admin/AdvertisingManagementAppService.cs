using Lazy.Abp.Ad.Admin.Permissions;
using Lazy.Abp.Ad.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Ad.Admin
{
    public class AdvertisingManagementAppService : CrudAppService<Advertising, AdvertisingDto, Guid, AdvertisingListInput, AdvertisingCreateUpdateDto, AdvertisingCreateUpdateDto>,
        IAdvertisingManagementAppService
    {
        protected override string GetPolicyName { get; set; } = AdAdminPermissions.Advertising.Default;
        protected override string GetListPolicyName { get; set; } = AdAdminPermissions.Advertising.Default;
        protected override string CreatePolicyName { get; set; } = AdAdminPermissions.Advertising.Create;
        protected override string UpdatePolicyName { get; set; } = AdAdminPermissions.Advertising.Update;
        protected override string DeletePolicyName { get; set; } = AdAdminPermissions.Advertising.Delete;

        private readonly IAdvertisingRepository _repository;

        public AdvertisingManagementAppService(IAdvertisingRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async override Task<PagedResultDto<AdvertisingDto>> GetListAsync(AdvertisingListInput input)
        {
            var totalCount = await _repository.GetCountAsync(input.AdvertisementType, input.IsActive, input.Filter);
            var advertisings = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.AdvertisementType, input.IsActive, input.Filter, input.IncludeDetails);

            return new PagedResultDto<AdvertisingDto>(
                    totalCount,
                    ObjectMapper.Map<List<Advertising>, List<AdvertisingDto>>(advertisings)
                );
        }

        [Authorize(AdAdminPermissions.Advertising.Update)]
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
