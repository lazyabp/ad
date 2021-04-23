using System.Threading.Tasks;
using LazyAbp.AdvertisementKit.Localization;
using LazyAbp.AdvertisementKit.Permissions;
using Volo.Abp.UI.Navigation;

namespace LazyAbp.AdvertisementKit.Web.Menus
{
    public class AdvertisementKitMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<AdvertisementKitResource>();
            //Add main menu items.

            context.Menu
                .AddItem(
                    new ApplicationMenuItem(AdvertisementKitMenus.Advertising, l["Menu:Advertising"], "/AdvertisementKit/Advertising")
                )
                .AddItem(
                    new ApplicationMenuItem(AdvertisementKitMenus.AdvertisingItem, l["Menu:AdvertisingItem"], "/AdvertisementKit/AdvertisingItem")
                )
                .AddItem(
                    new ApplicationMenuItem(AdvertisementKitMenus.UserAdvertising, l["Menu:UserAdvertising"], "/AdvertisementKit/UserAdvertising")
                );

            await Task.Delay(1);
        }
    }
}
