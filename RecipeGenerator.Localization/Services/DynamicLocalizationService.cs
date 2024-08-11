using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeGenerator.Localization.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Localization.Services
{
    /// <summary>
    /// Provides methods for dynamic change of application culture.
    /// </summary>
    public class DynamicLocalizationService : ObservableObject
    {
        private readonly ILogger<DynamicLocalizationService> logger;
        private readonly IOptions<DynamicLocalizationOptions> options;

        /// <summary>
        /// Creates a new instance of <see cref="DynamicLocalizationService"/> class.
        /// <br/> If options are invalid, restores default localization options.
        /// </summary>
        /// <param name="logger">Logger service.</param>
        /// <param name="options">Localization options.</param>
        public DynamicLocalizationService(ILogger<DynamicLocalizationService> logger, IOptions<DynamicLocalizationOptions> options)
        {
            this.logger = logger;
            this.options = options;
            var dynamicOptions = options.Value;
            if (dynamicOptions != null)
            {
                CurrentCulture = dynamicOptions.CurrentCulture!;
                Cultures = new ObservableCollection<CultureInfo>(dynamicOptions.Cultures!.Select(c => new CultureInfo(c)));
            }
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
            }
        }

        private ObservableCollection<CultureInfo> cultures = default!;
        /// <summary>
        /// Collection of available cultures.
        /// </summary>
        public ObservableCollection<CultureInfo> Cultures
        {
            get => cultures;
            protected set 
            { 
                SetProperty(ref cultures, value);
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
                logger.LogInformation($"Setting up new culture from string: {cultureName}");
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
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
