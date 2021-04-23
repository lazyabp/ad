using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.AdvertisementKit
{
    public static class AdvertisingItemEfCoreQueryableExtensions
    {
        public static IQueryable<AdvertisingItem> IncludeDetails(this IQueryable<AdvertisingItem> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}