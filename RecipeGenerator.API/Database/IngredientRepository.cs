using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database
{
    public class IngredientRepository : IIngredientRepository
    {
        public Task Add(IIngredient ingredient)
        {
            throw new NotImplementedException();
        }

        public Task Delete(IIngredient ingredient)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IIngredient>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IIngredient> GetByName()
        {
            throw new NotImplementedException();
        }

        public Task Update(IIngredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
