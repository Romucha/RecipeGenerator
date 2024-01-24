using RecipeGenerator.MVVM.Views.About;
using RecipeGenerator.MVVM.Views.Add;
using RecipeGenerator.MVVM.Views.Explore;
using RecipeGenerator.MVVM.Views.Home;
using RecipeGenerator.MVVM.Views.Settings;
using RecipeGenerator.MVVM.Views.Navigation;
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
        public static IServiceCollection AddPages(this IServiceCollection services)
        {
            services.AddTransient<AboutPage>();
            services.AddTransient<AddPage>();
            services.AddTransient<ExplorePage>();
            services.AddTransient<HomePage>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<NavigationTabbedPage>();
            return services;
        }
    }
}
