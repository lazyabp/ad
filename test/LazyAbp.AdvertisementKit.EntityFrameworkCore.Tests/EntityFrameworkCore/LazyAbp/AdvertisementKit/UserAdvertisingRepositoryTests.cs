using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace LazyAbp.AdvertisementKit.EntityFrameworkCore
{
    public class UserAdvertisingRepositoryTests : AdvertisementKitEntityFrameworkCoreTestBase
    {
        private readonly IUserAdvertisingRepository _userAdvertisingRepository;

        public UserAdvertisingRepositoryTests()
        {
            _userAdvertisingRepository = GetRequiredService<IUserAdvertisingRepository>();
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
