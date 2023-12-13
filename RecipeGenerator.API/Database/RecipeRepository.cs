using Microsoft.EntityFrameworkCore;
using RecipeGenerator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Database
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext recipeDbContext;

        public RecipeRepository(RecipeDbContext recipeDbContext)
        {
            this.recipeDbContext = recipeDbContext;
        }

        public async Task Add(Recipe recipe)
        {
            await recipeDbContext.Recipes.AddAsync(recipe);
            await recipeDbContext.SaveChangesAsync();
        }

        public async Task Delete(Recipe recipe)
        {
            recipeDbContext.Recipes.Remove(recipe);
            await recipeDbContext.SaveChangesAsync();
        }

        public IEnumerable<Recipe> GetAll()
        {
            return recipeDbContext.Recipes.AsNoTracking();
        }

        public async Task<Recipe> GetById(Guid id)
        {
            return await recipeDbContext.Recipes.FindAsync(id);
        }

        public async Task<Recipe> GetByName(string name)
        {
            return await recipeDbContext.Recipes.FirstOrDefaultAsync(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task Update(Recipe recipe)
        {
            recipe.UpdatedAt = DateTime.Now;
            recipeDbContext.Recipes.Update(recipe);
            await recipeDbContext.SaveChangesAsync();
        }
    }
}
