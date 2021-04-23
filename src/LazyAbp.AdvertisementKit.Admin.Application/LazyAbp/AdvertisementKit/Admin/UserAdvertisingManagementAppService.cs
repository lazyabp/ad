using LazyAbp.AdvertisementKit.Admin.Permissions;
using LazyAbp.AdvertisementKit.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.AdvertisementKit.Admin
{
    public class UserAdvertisingManagementAppService : ApplicationService, IUserAdvertisingManagementAppService
    {
        private readonly IUserAdvertisingRepository _repository;
        private readonly IAdvertisingItemRepository _advertisingItemRepository;

        public UserAdvertisingManagementAppService(IUserAdvertisingRepository repository,
            IAdvertisingItemRepository advertisingItemRepository)
        {
            _repository = repository;
            _advertisingItemRepository = advertisingItemRepository;
        }

        [Authorize(AdvertisementKitAdminPermissions.UserAdvertising.Default)]
        public async Task<UserAdvertisingDto> GetAsync(Guid id)
        {
            var userAd = await _repository.GetAsync(id);
            var adItem = await _advertisingItemRepository.GetAsync(userAd.AdvertisingItemId);

            var result = ObjectMapper.Map<UserAdvertising, UserAdvertisingDto>(userAd);
            result.AdvertisingItem = ObjectMapper.Map<AdvertisingItem, AdvertisingItemDto>(adItem);

            return result;
        }

        [Authorize(AdvertisementKitAdminPermissions.UserAdvertising.Default)]
        public async Task<PagedResultDto<UserAdvertisingDto>> GetListAsync(GetUserAdvertisingListInput input)
        {
            var totalCount = await _repository.GetCountAsync(input.UserId, input.CreatedAfter, input.CreatedBefore, input.ExpireAfter, input.ExpireBefore);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.UserId, input.CreatedAfter, input.CreatedBefore, input.ExpireAfter, input.ExpireBefore, input.IncludeDetails);

            var itemIds = list.Select(q => q.AdvertisingItemId).ToList();
            var adItems = await _advertisingItemRepository.GetByIdsAsync(itemIds);

            var ads = ObjectMapper.Map<List<UserAdvertising>, List<UserAdvertisingDto>>(list);
            ads.ForEach(x =>
            {
                var adItem = adItems.FirstOrDefault(x => x.Id == x.AdvertisingId);
                x.AdvertisingItem = ObjectMapper.Map<AdvertisingItem, AdvertisingItemDto>(adItem);
            });

            return new PagedResultDto<UserAdvertisingDto>(
                totalCount,
                ads
            );
        }
    }
}
