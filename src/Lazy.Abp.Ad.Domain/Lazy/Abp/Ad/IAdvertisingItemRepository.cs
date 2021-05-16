using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Ad
{
    public interface IAdvertisingItemRepository : IRepository<AdvertisingItem, Guid>
    {
        Task<List<AdvertisingItem>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
                Guid? advertisingId = null,
                bool? isActive = null,
                bool? isOnSale = null,
                //DateTime? startAfter = null,
                //DateTime? startBefore = null,
                //DateTime? expireAfter = null,
                //DateTime? expireBefore = null,
                string filter = null,
                CancellationToken cancellationToken = default
            );

        Task<List<AdvertisingItem>> GetListAsync(
                string sorting = null,
                int maxResultCount = 10,
                int skipCount = 0,
                Guid? advertisingId = null,
                bool? isActive = null,
                bool? isOnSale = null,
                //DateTime? startAfter = null,
                //DateTime? startBefore = null,
                //DateTime? expireAfter = null,
                //DateTime? expireBefore = null,
                string filter = null,
                CancellationToken cancellationToken = default
            );
    }
}