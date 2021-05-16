using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.Ad.EntityFrameworkCore
{
    public class AdModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public AdModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}