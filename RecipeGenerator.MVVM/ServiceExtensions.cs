using RecipeGenerator.MVVM.Views.About;
using RecipeGenerator.MVVM.Views.Add;
using RecipeGenerator.MVVM.Views.Explore;
using RecipeGenerator.MVVM.Views.Home;
using RecipeGenerator.MVVM.Views.Settings;
using RecipeGenerator.MVVM.Views.Navigation;
using RecipeGenerator.MVVM.Views.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.MVVM.Views;

namespace RecipeGenerator.MVVM
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
