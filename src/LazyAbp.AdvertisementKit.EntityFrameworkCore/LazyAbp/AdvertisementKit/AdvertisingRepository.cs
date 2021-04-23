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
    public class AdvertisingRepository : EfCoreRepository<IAdvertisementKitDbContext, Advertising, Guid>, IAdvertisingRepository
    {
        public AdvertisingRepository(IDbContextProvider<IAdvertisementKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Advertising> FindByIdAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .IncludeDetails(includeDetails)
                .AsNoTracking()
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Advertising> FindByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .IncludeDetails(includeDetails)
                .AsNoTracking()
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
            var query = GetListQuery(advertisementType, isActive, filter);

            var totalCount = await query.LongCountAsync(GetCancellationToken(cancellationToken));

            return totalCount;
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
            var query = GetListQuery(advertisementType, isActive, filter);

            var advertisingSpace = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return advertisingSpace;
        }

        protected virtual IQueryable<Advertising> GetListQuery(
            AdvertisementType? advertisementType = null,
            bool? isActive = null,
            string filter = null,
            bool includeDetails = false
        )
        {
            return DbSet.AsNoTracking()
                .IncludeDetails(includeDetails)
                .WhereIf(isActive.HasValue, e => false || e.IsActive == isActive)
                .WhereIf(advertisementType.HasValue, e => false || e.AdvertisementType == advertisementType.Value)
                .WhereIf(!string.IsNullOrEmpty(filter), 
                    e => false 
                    || e.Label.Contains(filter)
                    || e.ExpiredContent.Contains(filter)
                );
        }
    }
}