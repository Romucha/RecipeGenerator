﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeGenerator.Resources.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Resources.Services
{
    /// <summary>
    /// Provides methods for dynamic change of application culture.
    /// </summary>
    public class DynamicLocalizationService : ObservableObject
    {
        /// <summary>
        /// Creates a new instance of <see cref="DynamicLocalizationService"/> class.
        /// <br/> If options are invalid, restores default localization options.
        /// </summary>
        /// <param name="logger">Logger service.</param>
        /// <param name="options">Localization options.</param>
        public DynamicLocalizationService(ILogger<DynamicLocalizationService> logger, IOptions<DynamicLocalizationOptions> options)
        {
            this.logger = logger;
            var localization = options.Value;
            if (localization is null
                || string.IsNullOrEmpty(localization.CurrentCulture)
                || localization.Cultures is null
                || !localization.Cultures.Any())
            {
                localization = DynamicLocalizationOptions.DefaultLocalizationOptions;
            }

            restoreCulturesFromOptions(localization);
        }

        private string currentCulture = default!;

        /// <summary>
        /// Current culture.
        /// </summary>
        public string CurrentCulture
        {
            get => currentCulture;
            protected set => SetProperty(ref currentCulture, value);
        }

        private ObservableCollection<CultureInfo> cultures = default!;
        private readonly ILogger<DynamicLocalizationService> logger;

        /// <summary>
        /// Collection of available cultures.
        /// </summary>
        public ObservableCollection<CultureInfo> Cultures
        {
            get => cultures;
            protected set => SetProperty(ref cultures, value);
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

        private void restoreCulturesFromOptions(DynamicLocalizationOptions options)
        {
            try
            {
                logger.LogInformation("Restoring culture information from options...");
                if (options is null)
                {
                    throw new ArgumentNullException(nameof(options));
                }

                if (options.CurrentCulture is not null
                    && options.Cultures is not null)
                {
                    CurrentCulture = options.CurrentCulture;
                    Cultures = new(options.Cultures.Select(c => new CultureInfo(c)));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(restoreCulturesFromOptions));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
