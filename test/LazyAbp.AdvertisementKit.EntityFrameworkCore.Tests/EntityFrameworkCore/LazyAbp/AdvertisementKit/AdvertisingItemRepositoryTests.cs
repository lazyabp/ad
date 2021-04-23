using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace LazyAbp.AdvertisementKit.EntityFrameworkCore
{
    public class AdvertisingItemRepositoryTests : AdvertisementKitEntityFrameworkCoreTestBase
    {
        private readonly IAdvertisingItemRepository _advertisingItemRepository;

        public AdvertisingItemRepositoryTests()
        {
            _advertisingItemRepository = GetRequiredService<IAdvertisingItemRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
