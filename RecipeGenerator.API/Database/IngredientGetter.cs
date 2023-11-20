using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database
{
    internal class IngredientGetter : IIngredientGetter
    {
        private readonly IIngredientFactory ingredientFactory;
        public IngredientGetter(IIngredientFactory ingredientFactory) 
        {
            this.ingredientFactory = ingredientFactory;
        }

        public IEnumerable<IIngredient> Get()
        {
            ResourceManager resourceManager = new ResourceManager(typeof(Resources));

            ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            /*
             * 1. read all resources
             * 2. convert each dictionary entry into format (ingredient type, ingredient key name, ingredient property name, ingredient property value)
             * 3. group all list by ingredient key name
             * 4. create new ingredients from groupings
             */

            var resources = resourceSet.Cast<DictionaryEntry>()
                                       .Select(c => parseResourceDictionaryEntry(c))
                                       .GroupBy(c => c.keyName);
            foreach (var resource in resources) 
            {
                IngredientType type = resource.FirstOrDefault().type;
                string name = resource.FirstOrDefault(c => c.propertyName == "Name").propertyValue?.ToString();
                string description = resource.FirstOrDefault(c => c.propertyName == "Description").propertyValue?.ToString();
                Uri.TryCreate(resource.FirstOrDefault(c => c.propertyName == "Uri").propertyValue?.ToString(), UriKind.Absolute, out Uri uri);
                byte[] image = resource.FirstOrDefault(c => c.propertyName == "Image").propertyValue as byte[];

                yield return ingredientFactory.Create(name, description, uri, image, type);
            }
        }

        private (IngredientType type, string keyName, string propertyName, object propertyValue) parseResourceDictionaryEntry(DictionaryEntry entry)
        {
            string resourceKey = entry.Key.ToString();
            object resource = entry.Value;

            string[] resKeySplit = resourceKey.Split("_");
            IngredientType ingredientType = Enum.Parse<IngredientType>(resKeySplit[0]);
            string propertyName = resKeySplit.Last();
            object propertyValue = resource;
            string keyName = string.Join("_", resKeySplit.Skip(1).Take(resKeySplit.Length - 2));

            return (ingredientType, keyName, propertyName, propertyValue);
        }
    }
}
