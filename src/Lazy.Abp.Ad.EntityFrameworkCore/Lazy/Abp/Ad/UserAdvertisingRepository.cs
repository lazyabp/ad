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
    public class UserAdvertisingRepository : EfCoreRepository<IAdDbContext, UserAdvertising, Guid>, IUserAdvertisingRepository
    {
        public UserAdvertisingRepository(IDbContextProvider<IAdDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<UserAdvertising> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
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
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .WhereIf(canEdit.HasValue, e => e.CanEdit == canEdit)
                .WhereIf(expireAfter.HasValue, e => e.ExpireTime >= expireAfter.Value.Date)
                .WhereIf(expireBefore.HasValue, e => e.ExpireTime < expireBefore.Value.AddDays(1).Date)
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
            var query = await GetListQuery(userId, createdAfter, createdBefore, expireAfter, expireBefore);

            return await query
                .LongCountAsync(GetCancellationToken(cancellationToken));
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
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, createdAfter, createdBefore, expireAfter, expireBefore);

            return await query
                .OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual async Task<IQueryable<UserAdvertising>> GetListQuery(
            Guid? userId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            DateTime? expireAfter = null,
            DateTime? expireBefore = null
        )
        {
            return (await GetQueryableAsync())
                .AsNoTracking()
                .WhereIf(userId.HasValue, e => false || e.UserId == userId)
                .WhereIf(createdAfter.HasValue, e => false || e.CreationTime >= createdAfter.Value.Date)
                .WhereIf(createdBefore.HasValue, e => false || e.CreationTime < createdBefore.Value.AddDays(1).Date)
                .WhereIf(expireAfter.HasValue, e => false || e.ExpireTime >= expireAfter.Value.Date)
                .WhereIf(expireBefore.HasValue, e => false || e.ExpireTime < expireBefore.Value.AddDays(1).Date);
        }
    }
}