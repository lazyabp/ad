using Volo.Abp.Reflection;

namespace Lazy.Abp.Ad.Permissions
{
    public class AdPermissions
    {
        public const string GroupName = "Ad";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AdPermissions));
        }
    }
}
