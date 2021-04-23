using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.AdvertisementKit
{
    public interface IAdvertisingRepository : IRepository<Advertising, Guid>
    {
        Task<Advertising> FindByIdAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default);

        Task<Advertising> FindByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default);

        Task<List<Advertising>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            AdvertisementType? advertisementType = null,
            bool? isActive = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            AdvertisementType? advertisementType = null,
            bool? isActive = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}