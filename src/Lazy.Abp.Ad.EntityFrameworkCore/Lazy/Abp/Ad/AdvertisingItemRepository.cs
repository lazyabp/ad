using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Lazy.Abp.Ad.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Ad
{
    public class AdvertisingItemRepository : EfCoreRepository<IAdDbContext, AdvertisingItem, Guid>, IAdvertisingItemRepository
    {
        public AdvertisingItemRepository(IDbContextProvider<IAdDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<AdvertisingItem>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .Where(q => ids.Contains(q.Id))
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
            var query = await GetListQuery(advertisingId, isActive, isOnSale, /*startAfter, startBefore, expireAfter, expireBefore,*/ filter);

            return await query
                .LongCountAsync(GetCancellationToken(cancellationToken));
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
            var query = await GetListQuery(advertisingId, isActive, isOnSale, /*startAfter, startBefore, expireAfter, expireBefore,*/ filter);

            return await query
                .OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual async Task<IQueryable<AdvertisingItem>> GetListQuery(
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
            return (await GetQueryableAsync())
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