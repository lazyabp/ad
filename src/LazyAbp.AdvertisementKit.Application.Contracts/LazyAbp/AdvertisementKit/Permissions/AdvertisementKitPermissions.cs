using Volo.Abp.Reflection;

namespace LazyAbp.AdvertisementKit.Permissions
{
    public class AdvertisementKitPermissions
    {
        public const string GroupName = "AdvertisementKit";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AdvertisementKitPermissions));
        }
    }
}
