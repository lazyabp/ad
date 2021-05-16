using Lazy.Abp.Ad.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.Ad.Permissions
{
    public class AdPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AdPermissions.GroupName, L("Permission:Ad"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AdResource>(name);
        }
    }
}
