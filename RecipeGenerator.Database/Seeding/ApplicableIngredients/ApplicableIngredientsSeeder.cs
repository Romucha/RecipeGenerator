using AutoMapper;
using Microsoft.Extensions.Logging;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Resources.Descriptions.Ingredients;
using RecipeGenerator.Resources.Identifiers.Ingredients;
using RecipeGenerator.Resources.Images.Ingredients;
using RecipeGenerator.Resources.Links.Ingredients;
using RecipeGenerator.Resources.Names.Ingredients;
using System.Collections;
using System.Globalization;
using System.Resources;

namespace RecipeGenerator.Database.Seeding.ApplicableIngredients
{
    public class ApplicableIngredientsSeeder : BaseSeeder<GetApplicableIngredientResponse>
    {
        private readonly ILogger<ApplicableIngredientsSeeder> logger;
        private readonly IMapper mapper;

        public ApplicableIngredientsSeeder(ILogger<ApplicableIngredientsSeeder> logger, IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }

        public override IEnumerable<GetApplicableIngredientResponse> GetEntities()
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
                var images = imageManagers.SelectMany(getResourceEntries);

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
                                Id = Guid.NewGuid(),
                                Description = descriptionsManager.GetString(id) ?? id,
                                Name = namesManager.GetString(id) ?? id,
                                Image = (images.FirstOrDefault(c => c.Key.ToString() == id).Value as byte[]) ?? [],
                                Link = new Uri(linksManager.GetString(id) ?? "https://google.com"),
                                IngredientType = ingrtype,
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = DateTime.UtcNow,
                            });
                        }
                        catch (Exception)
                        {

                        }
                    }
                }

                return applicableIngredients.Select(mapper.Map<GetApplicableIngredientResponse>);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetEntities));
                return Enumerable.Empty<GetApplicableIngredientResponse>();
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public override async Task<IEnumerable<GetApplicableIngredientResponse>> GetEntitiesAsync()
        {
            return await Task.FromResult(GetEntities());
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
