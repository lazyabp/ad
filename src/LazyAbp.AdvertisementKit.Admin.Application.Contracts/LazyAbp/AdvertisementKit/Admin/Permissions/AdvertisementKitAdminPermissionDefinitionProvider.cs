using LazyAbp.AdvertisementKit.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LazyAbp.AdvertisementKit.Admin.Permissions
{
    public class AdvertisementKitAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AdvertisementKitAdminPermissions.GroupName, L("Permission:AdvertisementKitAdmin"));

            var advertisingPermission = myGroup.AddPermission(AdvertisementKitAdminPermissions.Advertising.Default, L("Permission:Advertising"));
            advertisingPermission.AddChild(AdvertisementKitAdminPermissions.Advertising.Create, L("Permission:Create"));
            advertisingPermission.AddChild(AdvertisementKitAdminPermissions.Advertising.Update, L("Permission:Update"));
            advertisingPermission.AddChild(AdvertisementKitAdminPermissions.Advertising.Delete, L("Permission:Delete"));

            var advertisingItemPermission = myGroup.AddPermission(AdvertisementKitAdminPermissions.AdvertisingItem.Default, L("Permission:AdvertisingItem"));
            advertisingItemPermission.AddChild(AdvertisementKitAdminPermissions.AdvertisingItem.Create, L("Permission:Create"));
            advertisingItemPermission.AddChild(AdvertisementKitAdminPermissions.AdvertisingItem.Update, L("Permission:Update"));
            advertisingItemPermission.AddChild(AdvertisementKitAdminPermissions.AdvertisingItem.Delete, L("Permission:Delete"));

            var userAdvertisingPermission = myGroup.AddPermission(AdvertisementKitAdminPermissions.UserAdvertising.Default, L("Permission:UserAdvertising"));
            userAdvertisingPermission.AddChild(AdvertisementKitAdminPermissions.UserAdvertising.Create, L("Permission:Create"));
            userAdvertisingPermission.AddChild(AdvertisementKitAdminPermissions.UserAdvertising.Update, L("Permission:Update"));
            userAdvertisingPermission.AddChild(AdvertisementKitAdminPermissions.UserAdvertising.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AdvertisementKitResource>(name);
        }
    }
}
