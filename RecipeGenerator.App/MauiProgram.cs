using Microsoft.Extensions.Logging;
using RecipeGenerator.API;
using RecipeGenerator.App.ViewModels;
using RecipeGenerator.RazorPages.ViewModels.About;
using RecipeGenerator.RazorPages.ViewModels.Explore;
using RecipeGenerator.RazorPages.ViewModels.Home;
using RecipeGenerator.RazorPages.ViewModels.Add;

namespace RecipeGenerator.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
             .UseMauiApp<App>()
             .ConfigureFonts(fonts =>
             {
                 fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
             });
            
            builder.Services.AddQuickGridEntityFrameworkAdapter();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddBlazorContextMenu();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Services.AddDatabase();
            builder.Services.AddTransient<MainVM>();
            builder.Services.AddTransient<AboutVM>();
            builder.Services.AddTransient<ExploreVM>();
            builder.Services.AddTransient<AddVM>();
            builder.Services.AddTransient<HomeVM>();

            return builder.Build();
        }
    }
}
