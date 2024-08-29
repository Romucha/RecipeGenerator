using RecipeGenerator.Localization.Services;

namespace RecipeGenerator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            var serviceProvider = 
#if WINDOWS10_0_17763_0_OR_GREATER
                MauiWinUIApplication.Current.Services;
#elif ANDROID || IOS || MACCATALYST
                IPlatformApplication.Current?.Services;
#else
                null;
#endif
            if (serviceProvider != null)
            {
                serviceProvider.GetRequiredService<DynamicLocalizationService>().Initialize();
            }
        }
    }
}
