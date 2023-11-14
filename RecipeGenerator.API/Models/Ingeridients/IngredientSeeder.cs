using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    public class IngredientSeeder : IIngredientSeeder
    {
        private readonly IIngredientFactory factory;

        public IngredientSeeder(IIngredientFactory ingredientFactory)
        {
            factory = ingredientFactory;
        }
        public IEnumerable<IIngredient> Seed()
        {
            throw new NotImplementedException();
        }

        /*
            Cereal,
            Dairy,
            Fruit,
            Herb,
            Meat,
            Nut,
            Oilseed,
            Other,
            Pulse,
            Seafood,
            Spice,
            Sugar,
            SugarProduct,
            Vegetable,
         */
        private IEnumerable<IIngredient> seedCereal()
        {
            yield return factory.Create();
        }
        private IEnumerable<IIngredient> seedDairy()
        {
            
        }
        private IEnumerable<IIngredient> seedFruit()
        {
            
        }
        private IEnumerable<IIngredient> seedHerb()
        {
            
        }
        private IEnumerable<IIngredient> seedMeat()
        {
            
        }
        private IEnumerable<IIngredient> seedNut()
        {
            
        }
        private IEnumerable<IIngredient> seedOilseed()
        {
            
        }
        private IEnumerable<IIngredient> seedPulse()
        {
            
        }
        private IEnumerable<IIngredient> seedSeafood()
        {
            
        }
        private IEnumerable<IIngredient> seedSpice()
        {
            
        }
        private IEnumerable<IIngredient> seedSugar()
        {
            
        }
        private IEnumerable<IIngredient> seedSugarProduct()
        {
            
        }
        private IEnumerable<IIngredient> seedVegetable()
        {
            
        }
    }
}
