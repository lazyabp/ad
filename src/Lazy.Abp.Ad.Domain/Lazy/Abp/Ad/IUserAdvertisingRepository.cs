using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Ad
{
    public interface IUserAdvertisingRepository : IRepository<UserAdvertising, Guid>
    {
        Task<UserAdvertising> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<UserAdvertising>> GetListByExpireTimeAsync(
            bool? canEdit = null,
            DateTime? expireAfter = null, 
            DateTime? expireBefore = null, 
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            Guid? userId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            DateTime? expireAfter = null,
            DateTime? expireBefore = null,
            CancellationToken cancellationToken = default
        );

        Task<List<UserAdvertising>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            DateTime? expireAfter = null,
            DateTime? expireBefore = null,
            CancellationToken cancellationToken = default
        );
    }
}