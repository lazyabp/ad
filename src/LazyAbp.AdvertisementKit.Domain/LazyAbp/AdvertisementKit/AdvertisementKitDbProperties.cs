namespace LazyAbp.AdvertisementKit
{
    public static class AdvertisementKitDbProperties
    {
        public static string DbTablePrefix { get; set; } = "AdvertisementKit";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "AdvertisementKit";
    }
}
