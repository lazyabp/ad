using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.Ad.MongoDB
{
    public class AdMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public AdMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}