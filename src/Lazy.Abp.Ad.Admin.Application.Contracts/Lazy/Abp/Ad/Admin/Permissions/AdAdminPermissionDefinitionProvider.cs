using Lazy.Abp.Ad.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.Ad.Admin.Permissions
{
    public class AdAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AdAdminPermissions.GroupName, L("Permission:AdAdmin"));

            var advertisingPermission = myGroup.AddPermission(AdAdminPermissions.Advertising.Default, L("Permission:Advertising"));
            advertisingPermission.AddChild(AdAdminPermissions.Advertising.Create, L("Permission:Create"));
            advertisingPermission.AddChild(AdAdminPermissions.Advertising.Update, L("Permission:Update"));
            advertisingPermission.AddChild(AdAdminPermissions.Advertising.Delete, L("Permission:Delete"));

            var advertisingItemPermission = myGroup.AddPermission(AdAdminPermissions.AdvertisingItem.Default, L("Permission:AdvertisingItem"));
            advertisingItemPermission.AddChild(AdAdminPermissions.AdvertisingItem.Create, L("Permission:Create"));
            advertisingItemPermission.AddChild(AdAdminPermissions.AdvertisingItem.Update, L("Permission:Update"));
            advertisingItemPermission.AddChild(AdAdminPermissions.AdvertisingItem.Delete, L("Permission:Delete"));

            var userAdvertisingPermission = myGroup.AddPermission(AdAdminPermissions.UserAdvertising.Default, L("Permission:UserAdvertising"));
            userAdvertisingPermission.AddChild(AdAdminPermissions.UserAdvertising.Create, L("Permission:Create"));
            userAdvertisingPermission.AddChild(AdAdminPermissions.UserAdvertising.Update, L("Permission:Update"));
            userAdvertisingPermission.AddChild(AdAdminPermissions.UserAdvertising.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AdResource>(name);
        }
    }
}
