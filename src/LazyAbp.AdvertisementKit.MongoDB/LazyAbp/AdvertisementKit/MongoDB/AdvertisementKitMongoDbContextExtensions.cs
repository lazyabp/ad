using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace LazyAbp.AdvertisementKit.MongoDB
{
    public static class AdvertisementKitMongoDbContextExtensions
    {
        public static void ConfigureAdvertisementKit(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AdvertisementKitMongoModelBuilderConfigurationOptions(
                AdvertisementKitDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}