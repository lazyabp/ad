using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.Ad.Web.Menus
{
    public class AdMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(AdMenus.Prefix, displayName: "Ad", "~/Ad", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}