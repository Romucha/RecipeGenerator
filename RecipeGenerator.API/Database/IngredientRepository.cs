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
        private readonly RecipeDbContext dbContext;
        public IngredientRepository(RecipeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Add(IIngredient ingredient)
        {
            throw new NotImplementedException();
        }

        public Task Delete(IIngredient ingredient)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IIngredient>> GetAll()
        {
            return await Task.FromResult(dbContext.Ingredients);
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
