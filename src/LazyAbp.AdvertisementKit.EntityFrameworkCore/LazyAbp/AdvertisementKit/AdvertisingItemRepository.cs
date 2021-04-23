using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using LazyAbp.AdvertisementKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.AdvertisementKit
{
    public class AdvertisingItemRepository : EfCoreRepository<IAdvertisementKitDbContext, AdvertisingItem, Guid>, IAdvertisingItemRepository
    {
        public AdvertisingItemRepository(IDbContextProvider<IAdvertisementKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<AdvertisingItem>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(q => ids.Contains(q.Id))
                    .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(
                Guid? advertisingId = null,
                bool? isActive = null,
                bool? isOnSale = null,
                //DateTime? startAfter = null,
                //DateTime? startBefore = null,
                //DateTime? expireAfter = null,
                //DateTime? expireBefore = null,
                string filter = null,
                CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(advertisingId, isActive, isOnSale, /*startAfter, startBefore, expireAfter, expireBefore,*/ filter);

            var totalCount = await query.LongCountAsync(GetCancellationToken(cancellationToken));

            return totalCount;
        }

        public virtual async Task<List<AdvertisingItem>> GetListAsync(
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
            )
        {
            var query = GetListQuery(advertisingId, isActive, isOnSale, /*startAfter, startBefore, expireAfter, expireBefore,*/ filter);

            var advertisings = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return advertisings;
        }

        protected virtual IQueryable<AdvertisingItem> GetListQuery(
                Guid? advertisingId = null,
                bool? isActive = null,
                bool? isOnSale = null,
                //DateTime? startAfter = null,
                //DateTime? startBefore = null,
                //DateTime? expireAfter = null,
                //DateTime? expireBefore = null,
                string filter = null
            )
        {
            return DbSet.AsNoTracking()
                .WhereIf(advertisingId.HasValue, e => false || e.AdvertisingId == advertisingId)
                .WhereIf(isActive.HasValue, e => false || e.IsActive == isActive)
                .WhereIf(isOnSale.HasValue, e => false || e.IsOnSale == isOnSale)
                //.WhereIf(startAfter.HasValue, e => false || e.StartTime >= startAfter)
                //.WhereIf(startBefore.HasValue, e => false || e.StartTime <= startBefore)
                //.WhereIf(expireAfter.HasValue, e => false || e.ExpireTime >= expireAfter)
                //.WhereIf(expireBefore.HasValue, e => false || e.ExpireTime >= expireBefore)
                .WhereIf(!string.IsNullOrEmpty(filter), 
                    e => false 
                    || e.Title.Contains(filter) 
                    || e.Url.Contains(filter)
                );
        }
    }
}