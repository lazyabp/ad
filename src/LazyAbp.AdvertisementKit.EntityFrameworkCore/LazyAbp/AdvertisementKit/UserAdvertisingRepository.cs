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
    public class UserAdvertisingRepository : EfCoreRepository<IAdvertisementKitDbContext, UserAdvertising, Guid>, IUserAdvertisingRepository
    {
        public UserAdvertisingRepository(IDbContextProvider<IAdvertisementKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<UserAdvertising> GetByIdAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await DbSet
                //.IncludeDetails(includeDetails)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<UserAdvertising>> GetListByExpireTimeAsync(
            bool? canEdit = null,
            DateTime? expireAfter = null,
            DateTime? expireBefore = null,
            CancellationToken cancellationToken = default
        )
        {
            return await DbSet.AsNoTracking()
                .WhereIf(canEdit.HasValue, e => e.CanEdit == canEdit)
                .WhereIf(expireAfter.HasValue, e => e.ExpireTime >= expireAfter)
                .WhereIf(expireBefore.HasValue, e => e.ExpireTime <= expireBefore)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(
            Guid? userId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            DateTime? expireAfter = null,
            DateTime? expireBefore = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = GetListQuery(userId, createdAfter, createdBefore, expireAfter, expireBefore);

            var totalCount = await query.LongCountAsync(GetCancellationToken(cancellationToken));

            return totalCount;
        }

        public virtual async Task<List<UserAdvertising>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            DateTime? expireAfter = null,
            DateTime? expireBefore = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        )
        {
            var query = GetListQuery(userId, createdAfter, createdBefore, expireAfter, expireBefore);

            var advertising = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return advertising;
        }

        protected virtual IQueryable<UserAdvertising> GetListQuery(
            Guid? userId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            DateTime? expireAfter = null,
            DateTime? expireBefore = null,
            bool includeDetails = false
        )
        {
            return DbSet.AsNoTracking()
                //.IncludeDetails(includeDetails)
                .WhereIf(userId.HasValue, e => false || e.UserId == userId)
                .WhereIf(createdAfter.HasValue, e => false || e.CreationTime >= createdAfter)
                .WhereIf(createdBefore.HasValue, e => false || e.CreationTime <= createdBefore)
                .WhereIf(expireAfter.HasValue, e => false || e.ExpireTime >= expireAfter)
                .WhereIf(expireBefore.HasValue, e => false || e.ExpireTime <= expireBefore);
        }
    }
}