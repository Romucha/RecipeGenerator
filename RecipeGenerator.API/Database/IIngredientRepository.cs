using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database
{
    public interface IIngredientRepository
    {
        Task<IIngredient> GetByName();

        Task<IEnumerable<IIngredient>> GetAll();

        Task Add(IIngredient ingredient);

        Task Update(IIngredient ingredient);

        Task Delete(IIngredient ingredient);
    }
}
