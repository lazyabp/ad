using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace LazyAbp.AdvertisementKit
{
    public class UserAdvertisingManager : AdvertisementKitDomainService
    {
        private readonly IUserAdvertisingRepository _repository;
        private readonly IAdvertisingItemRepository _advertisingItemRepository;

        public UserAdvertisingManager(IUserAdvertisingRepository repository,
            IAdvertisingItemRepository advertisingItemRepository)
        {
            _repository = repository;
            _advertisingItemRepository = advertisingItemRepository;
        }

        public async Task<UserAdvertising> GetByUserIdAndIdAsync(Guid id, Guid userId)
        {
            var ad = await _repository.GetByIdAsync(id);

            if (ad.UserId == userId)
                return ad;
            else
                return null;
        }

        public async Task SetAsPaid(Guid id, DateTime expireTime)
        {
            if (expireTime < Clock.Now)
                throw new Exception("InvalidExpireTime");

            var userAd = await _repository.GetAsync(id);
            var adItem = await _advertisingItemRepository.GetAsync(userAd.AdvertisingItemId);

            if (adItem.IsOnSale)
                throw new Exception("AdPositonHasBeenSoldOut");

            userAd.SetExpireTime(expireTime);
            if (expireTime > Clock.Now)
            {
                userAd.SetCanEdit(true);
                adItem.SetOnSale(false);
            }

            await _repository.UpdateAsync(userAd);
            await _advertisingItemRepository.UpdateAsync(adItem);
        }

        /// <summary>
        /// 释放将过期的用户广告
        /// </summary>
        /// <returns></returns>
        public async Task ExpireCheckingAsync()
        {
            var userAds = await _repository.GetListByExpireTimeAsync(
                true,
                null,
                Clock.Now
            );

            var itemIds = userAds.Select(q => q.AdvertisingItemId).ToList();
            var items = await _advertisingItemRepository.GetByIdsAsync(itemIds);

            foreach(var userAd in userAds)
            {
                var item = items.FirstOrDefault(q => q.Id == userAd.AdvertisingItemId);

                userAd.SetCanEdit(false);
                item.SetOnSale(true);

                await _repository.UpdateAsync(userAd);
                await _advertisingItemRepository.UpdateAsync(item);                
            }
        }

        public async Task SetAsExpiredAsync(Guid id)
        {
            var userAd = await _repository.GetAsync(id);
            var adItem = await _advertisingItemRepository.GetAsync(userAd.AdvertisingItemId);

            if (userAd.ExpireTime < Clock.Now)
            {
                userAd.SetCanEdit(false);
                adItem.SetOnSale(true);

                await _repository.UpdateAsync(userAd);
                await _advertisingItemRepository.UpdateAsync(adItem);
            }
        }
    }
}
