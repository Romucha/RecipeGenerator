﻿using Microsoft.Extensions.Logging;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Resources.Descriptions.Ingredients;
using RecipeGenerator.Resources.Identifiers.Ingredients;
using RecipeGenerator.Resources.Images.Ingredients;
using RecipeGenerator.Resources.Links.Ingredients;
using RecipeGenerator.Resources.Names.Ingredients;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Seeding.ApplicableIngredients
{
    public class ApplicableIngredientsSeeder : BaseSeeder<ApplicableIngredient>
    {
        private readonly ILogger<ApplicableIngredientsSeeder> logger;

        public ApplicableIngredientsSeeder(ILogger<ApplicableIngredientsSeeder> logger)
        {
            this.logger = logger;
        }

        public override async Task<IEnumerable<ApplicableIngredient>> GetEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                try
                {
                    logger.LogInformation("Creating list of inredients...");
                    ResourceManager identifiersManager = new(typeof(Identifiers_Ingredients));
                    var identifiers = getResourceEntries(identifiersManager).Select(c => c.Value!.ToString());

                    ResourceManager descriptionsManager = new(typeof(Descriptions_Ingredients));
                    ResourceManager linksManager = new(typeof(Links_Ingredients));
                    ResourceManager namesManager = new(typeof(Names_Ingredients));
                    ResourceManager typesManager = new(typeof(Names_IngredientTypes));

                    ResourceManager[] imageManagers =
                    [
                        new(typeof(Images_CerealsAndPulses)),
                        new(typeof(Images_DairyProducts)),
                        new(typeof(Images_Fruits)),
                        new(typeof(Images_Meat)),
                        new(typeof(Images_NutsAndOilseeds)),
                        new(typeof(Images_OtherIngredients)),
                        new(typeof(Images_Seafood)),
                        new(typeof(Images_SpicesAndHerbs)),
                        new(typeof(Images_SugarAndSugarProducts)),
                        new(typeof(Images_Vegetables))
                    ];
                    var images = imageManagers.SelectMany(c => getResourceEntries(c));

                    List<ApplicableIngredient> applicableIngredients = new();

                    foreach (var id in identifiers)
                    {
                        if (id != null)
                        {
                            try
                            {
                                var typeid = id.Split('_').FirstOrDefault();
                                var ingrtype = Enum.Parse<IngredientType>(typeid!);

                                applicableIngredients.Add(new ApplicableIngredient()
                                {
                                    Description = descriptionsManager.GetString(id)!,
                                    Name = namesManager.GetString(id)!,
                                    Image = Encoding.UTF8.GetString((images.FirstOrDefault(c => c.Key.ToString() == id).Value as byte[])!)!,
                                    Link = new Uri(linksManager.GetString(id)!),
                                    IngredientType = ingrtype,
                                });
                            }
                            catch (Exception ex)
                            {
                                //SOMETIMES ERROR SHOWS UP BECAUSE OF BROKEN IMAGE. FIX
                            }
                        }
                    }

                    return applicableIngredients;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, nameof(GetEntitiesAsync));
                    return Enumerable.Empty<ApplicableIngredient>();
                }
                finally
                {
                    logger.LogInformation("Done.");
                }
            }, cancellationToken);
        }

        private IEnumerable<DictionaryEntry> getResourceEntries(ResourceManager resourceManager)
        {
            ResourceSet? resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            if (resourceSet != null)
            {
                return resourceSet.Cast<DictionaryEntry>().OrderBy(c => c.Key);
            }

            return Enumerable.Empty<DictionaryEntry>();
        }
    }
}