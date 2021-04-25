using System;
using LazyAbp.AdvertisementKit.Permissions;
using LazyAbp.AdvertisementKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.Users;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using System.Linq;

namespace LazyAbp.AdvertisementKit
{
    [Authorize]
    public class UserAdvertisingAppService : CrudAppService<UserAdvertising, UserAdvertisingDto, Guid, GetUserAdvertisingListInput, CreateUpdateUserAdvertisingDto, CreateUpdateUserAdvertisingDto>,
        IUserAdvertisingAppService
    {
        private readonly IUserAdvertisingRepository _repository;
        private readonly IAdvertisingItemRepository _advertisingItemRepository;

        public UserAdvertisingAppService(IUserAdvertisingRepository repository,
            IAdvertisingItemRepository advertisingItemRepository) : base(repository)
        {
            _repository = repository;
            _advertisingItemRepository = advertisingItemRepository;
        }

        public override async Task<UserAdvertisingDto> GetAsync(Guid id)
        {
            var userAd = await _repository.GetAsync(id);
            var adItem = await _advertisingItemRepository.GetAsync(userAd.AdvertisingItemId);

            var result = ObjectMapper.Map<UserAdvertising, UserAdvertisingDto>(userAd);
            result.AdvertisingItem = ObjectMapper.Map<AdvertisingItem, AdvertisingItemDto>(adItem);

            return result;
        }

        public async override Task<UserAdvertisingDto> CreateAsync(CreateUpdateUserAdvertisingDto input)
        {
            var adItem = await _advertisingItemRepository.GetAsync(input.AdvertisingItemId);
            if (!adItem.IsOnSale)
                throw new UserFriendlyException(L["AdPositonHasBeenSoldOut"]);

            var userAd = new UserAdvertising(GuidGenerator.Create(), CurrentUser.TenantId, CurrentUser.GetId(), input.AdvertisingItem.AdvertisingItemId, Clock.Now);
            userAd = await _repository.InsertAsync(userAd);

            var result = ObjectMapper.Map<UserAdvertising, UserAdvertisingDto>(userAd);
            result.AdvertisingItem = ObjectMapper.Map<AdvertisingItem, AdvertisingItemDto>(adItem);

            return result;
        }

        public async override Task<UserAdvertisingDto> UpdateAsync(Guid id, CreateUpdateUserAdvertisingDto input)
        {
            var userAd = await _repository.GetByIdAsync(id);
            if (CurrentUser.GetId() != userAd.UserId || !userAd.CanEdit)
                throw new UserFriendlyException(L["NoPermissions"]);

            var adItem = await _advertisingItemRepository.GetAsync(input.AdvertisingItemId);

            adItem.Update(input.AdvertisingItem.Title, input.AdvertisingItem.Url, input.AdvertisingItem.Content, input.AdvertisingItem.Alt);
            adItem.SetActive(input.AdvertisingItem.IsActive);
            adItem = await _advertisingItemRepository.UpdateAsync(adItem);

            var result = ObjectMapper.Map<UserAdvertising, UserAdvertisingDto>(userAd);
            result.AdvertisingItem = ObjectMapper.Map<AdvertisingItem, AdvertisingItemDto>(adItem);

            return result;
        }

        public async override Task<PagedResultDto<UserAdvertisingDto>> GetListAsync(GetUserAdvertisingListInput input)
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
