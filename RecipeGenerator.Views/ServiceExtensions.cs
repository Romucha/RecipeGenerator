using RecipeGenerator.Views.Views.About;
using RecipeGenerator.Views.Views.Add;
using RecipeGenerator.Views.Views.Explore;
using RecipeGenerator.Views.Views.Home;
using RecipeGenerator.Views.Views.Settings;
using RecipeGenerator.Views.Views.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.Views.Views;

namespace RecipeGenerator.Views
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddViews(this IServiceCollection services)
        {
            services.AddTransient<AboutView>();
            services.AddTransient<AddView>();
            services.AddTransient<ExploreView>();
            services.AddTransient<HomeView>();
            services.AddTransient<SettingsView>();
            services.AddTransient<NavigationPanelView>();
            services.AddTransient<BodyPanelView>();
            return services;
        }
    }
}
