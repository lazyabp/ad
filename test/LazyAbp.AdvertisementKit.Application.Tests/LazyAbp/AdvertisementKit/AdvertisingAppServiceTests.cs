using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace LazyAbp.AdvertisementKit.LazyAbp.AdvertisementKit
{
    public class AdvertisingAppServiceTests : AdvertisementKitApplicationTestBase
    {
        private readonly IAdvertisingAppService _advertisingAppService;

        public AdvertisingAppServiceTests()
        {
            _advertisingAppService = GetRequiredService<IAdvertisingAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
