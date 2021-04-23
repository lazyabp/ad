using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.AdvertisementKit
{
    public static class UserAdvertisingEfCoreQueryableExtensions
    {
        public static IQueryable<UserAdvertising> IncludeDetails(this IQueryable<UserAdvertising> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable;
                 //.Include(x => x.AdvertisingItem);
        }
    }
}