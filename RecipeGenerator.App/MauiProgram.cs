﻿using Microsoft.Extensions.Logging;
using RecipeGenerator.API;
using RecipeGenerator.Views;

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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services
                .AddTransient<Shell, AppShell>()
                .AddDatabase()
                .AddViews();

            return builder.Build();
        }
    }
}
