using Microsoft.EntityFrameworkCore;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database.Ingredients
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly RecipeDbContext dbContext;
        public IngredientRepository(RecipeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            return await Task.FromResult(dbContext.Ingredients);
        }

        public async Task<Ingredient> GetByName(string name)
        {
            return await dbContext.Ingredients.FirstOrDefaultAsync(x => x.Name == name);
        }

        public IEnumerable<Ingredient> GetByType(IngredientType type)
        {
            return dbContext.Ingredients.Where(c => c.IngredientType == type);
        }

        public async Task Update(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
