using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeGenerator.Localization.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace RecipeGenerator.Localization.Services
{
    /// <summary>
    /// Provides methods for dynamic change of application culture.
    /// </summary>
    public class DynamicLocalizationService : ObservableObject
    {
        private readonly ILogger<DynamicLocalizationService> logger;
        private readonly IOptions<DynamicLocalizationOptions> options;
        private readonly ConfigurationFileWriterService configurationFileWriterService;

        /// <summary>
        /// Creates a new instance of <see cref="DynamicLocalizationService"/> class.
        /// <br/> If options are invalid, restores default localization options.
        /// </summary>
        /// <param name="logger">Logger service.</param>
        /// <param name="options">Localization options.</param>
        public DynamicLocalizationService(ILogger<DynamicLocalizationService> logger, IOptions<DynamicLocalizationOptions> options, ConfigurationFileWriterService configurationFileWriterService)
        {
            this.logger = logger;
            this.options = options;
            this.configurationFileWriterService = configurationFileWriterService;
            var dynamicOptions = options.Value;
        }

        private string currentCulture = default!;
        /// <summary>
        /// Current culture.
        /// </summary>
        public string CurrentCulture
        {
            get => currentCulture;
            protected set
            {
                SetProperty(ref currentCulture, value);
                options.Value.CurrentCulture = value;
                configurationFileWriterService.Write<DynamicLocalizationOptions>(nameof(CurrentCulture), value);
            }
        }

        private ObservableCollection<CultureInfo> cultures = new();
        /// <summary>
        /// Collection of available cultures.
        /// </summary>
        public ObservableCollection<CultureInfo> Cultures
        {
            get => cultures;
            protected set
            {
                SetProperty(ref cultures, value);
                configurationFileWriterService.Write<DynamicLocalizationOptions>(nameof(Cultures), value.Select(c => c.Name));
            }
        }

        public void Initialize()
        {
            if (Cultures == null || Cultures.Count == 0)
            {
                if (options.Value.Cultures == null || !options.Value.Cultures.Any())
                {
                    Cultures = new(DynamicLocalizationOptions.DefaultLocalizationOptions.Cultures!.Select(c => new CultureInfo(c)).OrderBy(c => c.Name));
                }
                else
                {
                    cultures = new(options.Value.Cultures.Select(c => new CultureInfo(c)).OrderBy(c => c.Name));
                }
            }

            if (string.IsNullOrWhiteSpace(CurrentCulture))
            {
                var currentCulture = CultureInfo.CurrentUICulture.Name;
                if (!string.IsNullOrEmpty(options.Value.CurrentCulture))
                {
                    currentCulture = options.Value.CurrentCulture;
                }

                if (!cultures.Any(c => c.Name == currentCulture))
                {
                    currentCulture = DynamicLocalizationOptions.DefaultLocalizationOptions.CurrentCulture;
                }
                SetCulture(currentCulture!);
            }
        }

        /// <summary>
        /// Set culture.
        /// </summary>
        /// <param name="cultureName">A new culture name.</param>
        public void SetCulture(string cultureName)
        {
            try
            {
                var culture = Cultures.FirstOrDefault(c => c.Name == cultureName);
                if (culture is not null)
                {
                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;
                    CultureInfo.DefaultThreadCurrentCulture = culture;
                    CultureInfo.DefaultThreadCurrentUICulture = culture;
                    CurrentCulture = cultureName;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SetCulture));
            }
        }
    }
}
