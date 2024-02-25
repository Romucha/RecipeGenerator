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

        public IEnumerable<GetIngredientDTO> Get()
        {
            /*
             * 1. Get list of ingredients from ingredient name resources. Element of list is made from entry name with "_Image" part replaced by "".
             *    Also get names.
             * 2. For all other components get values from resource managers get values by id.
             */
            var ids = getIngredientComponentIds();
            //get ingreddient names
            var namemanager = new ResourceManager(typeof(IngredientNames));
            //get ingredient descriptions
            var descmanager = new ResourceManager(typeof(IngredientDescriptions));
            //get ingredient links
            var linkmanager = new ResourceManager(typeof(IngredientLinks));
            //get ingredient images
            var imgmanager = new ResourceManager(typeof(IngredientImages));

            foreach (var id in ids)
            {
                //get name
                var name = getIngredientComponentResource<string>(namemanager, id);
                //get description
                var desc = getIngredientComponentResource<string>(descmanager, id);
                //get link
                var _link = getIngredientComponentResource<string>(linkmanager, id);
                Uri.TryCreate(_link, UriKind.Absolute, out Uri link);
                //get image
                var image = getIngredientComponentResource<string>(imgmanager, id);
                //get type
                var typeid = id.Split('_').FirstOrDefault();
                var ingrtype = Enum.Parse<IngredientType>(typeid);
                yield return new GetIngredientDTO
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Description = desc,
                    Image = image,
                    IngredientType = ingrtype,
                    Link = link,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
            }
        }        

        private IEnumerable<string> getIngredientComponentIds()
        {
            ResourceManager manager = new ResourceManager(typeof(IngredientIds));
            var entries = manager.GetResourceSet(CultureInfo.CurrentUICulture, true, true).Cast<DictionaryEntry>().OrderBy(c => c.Key);
            return entries.Select(c => c.Value.ToString());
        }

        private T getIngredientComponentResource<T>(ResourceManager manager, string componentId) where T : class
        {
            var entry = manager.GetObject(componentId);
            return entry as T;
        }
    }
}
