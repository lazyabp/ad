using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.AdvertisementKit
{
    public static class AdvertisingEfCoreQueryableExtensions
    {
        public static IQueryable<Advertising> IncludeDetails(this IQueryable<Advertising> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                 .Include(x => x.Items);
        }
    }
}