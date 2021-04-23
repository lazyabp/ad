using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace LazyAbp.AdvertisementKit.LazyAbp.AdvertisementKit
{
    public class UserAdvertisingAppServiceTests : AdvertisementKitApplicationTestBase
    {
        private readonly IUserAdvertisingAppService _userAdvertisingAppService;

        public UserAdvertisingAppServiceTests()
        {
            _userAdvertisingAppService = GetRequiredService<IUserAdvertisingAppService>();
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
