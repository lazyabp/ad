using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using LazyAbp.AdvertisementKit.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace LazyAbp.AdvertisementKit
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class AdvertisementKitDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AdvertisementKitDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AdvertisementKitResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/LazyAbp/AdvertisementKit/Localization");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("AdvertisementKit", typeof(AdvertisementKitResource));
            });
        }
    }
}
