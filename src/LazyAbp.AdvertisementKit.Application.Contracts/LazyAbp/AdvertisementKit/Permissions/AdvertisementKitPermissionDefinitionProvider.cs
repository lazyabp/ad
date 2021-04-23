using LazyAbp.AdvertisementKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LazyAbp.AdvertisementKit.Permissions
{
    public class AdvertisementKitPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AdvertisementKitPermissions.GroupName, L("Permission:AdvertisementKit"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AdvertisementKitResource>(name);
        }
    }
}
