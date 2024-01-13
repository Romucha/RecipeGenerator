using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Properties;
using RecipeGenerator.API.Properties.Ingredients;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database.Ingredients
{
    internal class IngredientGetter : IIngredientGetter
    {
        private class DictionaryEntryDTO
        {
            public IngredientType type { get; set; }
            public string keyName { get; set; }
            public string propertyName { get; set; }
            public object propertyValue { get; set; }
        }

        private readonly IIngredientFactory ingredientFactory;
        public IngredientGetter(IIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        public IEnumerable<CreateIngredientDTO> Get()
        {
            ResourceManager resourceManager = new ResourceManager(typeof(IngredientNames));

            ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            /*
             * 1. read all resources
             * 2. convert each dictionary entry into format (ingredient type, ingredient key name, ingredient property name, ingredient property value)
             * 3. group all list by ingredient key name
             * 4. create new ingredients from groupings
             */

            var resources = resourceSet.Cast<DictionaryEntry>()
                                       .Select(parseResourceDictionaryEntry)
                                       .GroupBy(c => c.keyName);
            foreach (var resource in resources)
            {
                IngredientType type = resource.FirstOrDefault().type;
                var nameres = resource.FirstOrDefault(c => c.propertyName == "Name");
                string name = nameres == null ? string.Empty : nameres.propertyValue?.ToString();
                var descres = resource.FirstOrDefault(c => c.propertyName == "Description");
                string description = descres == null ? string.Empty : descres.propertyValue?.ToString();
                var urires = resource.FirstOrDefault(c => c.propertyName == "Uri");
                Uri uri = null;
                if (urires != null)
                    Uri.TryCreate(urires.propertyValue?.ToString(), UriKind.Absolute, out uri);
                else
                    //rick roll for now
                    Uri.TryCreate("https://www.youtube.com/watch?v=dQw4w9WgXcQ", UriKind.Absolute, out uri);
                var imageres = resource.FirstOrDefault(c => c.propertyName == "Image");
                byte[] image = imageres == null ? null : descres.propertyValue as byte[];
                if (!string.IsNullOrEmpty(name))
                {
                    yield return new CreateIngredientDTO
                    {
                        Name = name,
                        Description = description,
                        CreatedAt = DateTime.Now,
                        Image = image,
                        IngredientType = type,
                        Link = uri,
                        UpdatedAt = DateTime.Now,
                    };
                }
            }
        }

        private DictionaryEntryDTO parseResourceDictionaryEntry(DictionaryEntry entry)
        {
            string resourceKey = entry.Key.ToString();
            object resource = entry.Value;

            string[] resKeySplit = resourceKey.Split("_");
            IngredientType ingredientType = Enum.Parse<IngredientType>(resKeySplit[0]);
            string propertyName = resKeySplit.Last();
            object propertyValue = resource;
            string keyName = string.Join("_", resKeySplit.Skip(1).Take(resKeySplit.Length - 2));

            return new DictionaryEntryDTO
            {
                propertyName = propertyName,
                propertyValue = propertyValue,
                keyName = keyName,
                type = ingredientType
            };
        }
    }
}
