using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace LazyAbp.AdvertisementKit.EntityFrameworkCore
{
    public class AdvertisingRepositoryTests : AdvertisementKitEntityFrameworkCoreTestBase
    {
        private readonly IAdvertisingRepository _advertisingRepository;

        public AdvertisingRepositoryTests()
        {
            _advertisingRepository = GetRequiredService<IAdvertisingRepository>();
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
