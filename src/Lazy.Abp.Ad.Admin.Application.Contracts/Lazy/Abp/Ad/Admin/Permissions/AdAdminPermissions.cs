using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Reflection;

namespace Lazy.Abp.Ad.Admin.Permissions
{
    public class AdAdminPermissions
    {
        public const string GroupName = "Ad.Admin";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AdAdminPermissions));
        }

        public class Advertising
        {
            public const string Default = GroupName + ".Advertising";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class AdvertisingItem
        {
            public const string Default = GroupName + ".AdvertisingItem";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class UserAdvertising
        {
            public const string Default = GroupName + ".UserAdvertising";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string TriggerAsExpired = Default + ".TriggerAsExpired";
        }
    }
}
