using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace LazyAbp.AdvertisementKit.MongoDB
{
    public class AdvertisementKitMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public AdvertisementKitMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}