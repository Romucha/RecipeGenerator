using RecipeGenerator.API.Models;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetByName(string name);
        Task<Recipe> GetById(Guid id);

        IEnumerable<Recipe> GetAll();

        Task Add(Recipe recipe);

        Task Update(Recipe recipe);

        Task Delete(Recipe recipe);
    }
}
