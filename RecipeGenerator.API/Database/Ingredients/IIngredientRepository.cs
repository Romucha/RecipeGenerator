using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database.Ingredients
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetByName(string name);

        Task<IEnumerable<Ingredient>> GetAll();

        Task<IEnumerable<Ingredient>> GetByType(IngredientType type);

        Task Add(Ingredient ingredient);

        Task Update(Ingredient ingredient);

        Task Delete(Ingredient ingredient);
    }
}
