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
    public class AdvertisingRepository : EfCoreRepository<IAdDbContext, Advertising, Guid>, IAdvertisingRepository
    {
        public AdvertisingRepository(IDbContextProvider<IAdDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Advertising>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.Items);
        }

        public async Task<Advertising> FindByIdAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .IncludeIf(includeDetails, q => q.Items)
                .AsNoTracking()
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Advertising> FindByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .IncludeIf(includeDetails, q => q.Items)
                .Where(e => e.Name == name)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            AdvertisementType? advertisementType = null,
            bool? isActive = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(advertisementType, isActive, filter);

            return await query
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Advertising>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            AdvertisementType? advertisementType = null,
            bool? isActive = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(advertisementType, isActive, filter);

            return await query
                .OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual async Task<IQueryable<Advertising>> GetListQuery(
            AdvertisementType? advertisementType = null,
            bool? isActive = null,
            string filter = null,
            bool includeDetails = false
        )
        {
            return (await GetQueryableAsync())
                .AsNoTracking()
                .IncludeIf(includeDetails, q => q.Items)
                .WhereIf(isActive.HasValue, q => q.IsActive == isActive)
                .WhereIf(advertisementType.HasValue, q => q.AdvertisementType == advertisementType)
                .WhereIf(!string.IsNullOrEmpty(filter), 
                    e => false 
                    || e.Label.Contains(filter)
                    || e.ExpiredContent.Contains(filter)
                );
        }
    }
}