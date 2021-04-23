using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LazyAbp.AdvertisementKit.EntityFrameworkCore
{
    public class AdvertisementKitModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public AdvertisementKitModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}