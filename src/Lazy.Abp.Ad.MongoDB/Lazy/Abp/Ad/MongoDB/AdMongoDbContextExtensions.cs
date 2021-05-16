using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.Ad.MongoDB
{
    public static class AdMongoDbContextExtensions
    {
        public static void ConfigureAd(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AdMongoModelBuilderConfigurationOptions(
                AdDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}