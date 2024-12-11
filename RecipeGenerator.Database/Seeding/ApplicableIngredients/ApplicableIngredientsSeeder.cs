using AutoMapper;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Resources.Descriptions.Ingredients;
using RecipeGenerator.Resources.Extra.Ingredients;
using RecipeGenerator.Resources.Identifiers.Ingredients;
using RecipeGenerator.Resources.Images.Ingredients;
using RecipeGenerator.Resources.Links.Ingredients;
using RecipeGenerator.Resources.Names.Ingredients;
using System.Collections;
using System.Globalization;
using System.Resources;

namespace RecipeGenerator.Database.Seeding.ApplicableIngredients
{
    public class ApplicableIngredientsSeeder
    {
        private readonly ILogger<ApplicableIngredientsSeeder> logger;
        private readonly IMapper mapper;
        private readonly RecipeGeneratorDbContext dbContext;

        public ApplicableIngredientsSeeder(ILogger<ApplicableIngredientsSeeder> logger, IMapper mapper, RecipeGeneratorDbContext dbContext)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task SeedDatabaseAsync()
        {
            try
            {
                if (!dbContext.ApplicableIngredients.Any())
                {
                    var ingredients = await getEntitiesAsync();
                    await dbContext.ApplicableIngredients.AddRangeAsync(ingredients);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SeedDatabaseAsync));
            }
        }

        private async Task<IEnumerable<ApplicableIngredient>> getEntitiesAsync()
        {
            try
            {
                ResourceManager identifiersManager = new(typeof(Identifiers_Ingredients));
                var identifiers = getResourceEntries(identifiersManager).Select(c => c.Value!.ToString());

                ResourceManager idsManager = new(typeof(Ids_Ingerdients));
                ResourceManager descriptionsManager = await Task.Run(() => new ResourceManager(typeof(Descriptions_Ingredients)));
                ResourceManager linksManager = await Task.Run(() => new ResourceManager(typeof(Links_Ingredients)));
                ResourceManager namesManager = await Task.Run(() => new ResourceManager(typeof(Names_Ingredients)));
                ResourceManager typesManager = await Task.Run(() => new ResourceManager(typeof(Names_IngredientTypes)));
                ResourceManager measurementManager = await Task.Run(() => new ResourceManager(typeof(MeasurementTypes_Ingredients)));

                ResourceManager[] imageManagers = await Task.Run(() =>
                new ResourceManager[]
                {
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
                });
                var images = await Task.Run(() => imageManagers.SelectMany(getResourceEntries));

                List<ApplicableIngredient> applicableIngredients = new();

                foreach (var id in identifiers)
                {
                    if (id != null)
                    {
                        try
                        {
                            await Task.Run(() =>
                            {
                                var typeid = id.Split('_').FirstOrDefault();
                                var ingrtype = Enum.Parse<IngredientType>(typeid!);
                                var msrtype = (MeasurementType)int.Parse(measurementManager.GetString(id) ?? measurementManager.GetString(id) ?? MeasurementType.None.ToString());

                                applicableIngredients.Add(new ApplicableIngredient()
                                {
                                    Id = Convert.ToInt32(idsManager.GetString(id)),
                                    Description = descriptionsManager.GetString(id) ?? id,
                                    Name = namesManager.GetString(id) ?? id,
                                    Image = (images.FirstOrDefault(c => c.Key.ToString() == id).Value as byte[]) ?? [],
                                    Link = new Uri(linksManager.GetString(id) ?? "https://google.com"),
                                    IngredientType = ingrtype,
                                    MeasurementType = msrtype,
                                    CreatedAt = DateTime.UtcNow,
                                    UpdatedAt = DateTime.UtcNow,
                                });
                            });
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, nameof(ApplicableIngredientsSeeder));
                        }
                    }
                }

                return applicableIngredients.OrderBy(c => c.Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(getEntitiesAsync));
                return Enumerable.Empty<ApplicableIngredient>();
            }
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
