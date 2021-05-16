namespace Lazy.Abp.Ad
{
    public static class AdDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Ad";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Ad";
    }
}
