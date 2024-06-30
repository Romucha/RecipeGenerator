using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Recipe> RecipeRepository => throw new NotImplementedException();

        public IRepository<Step> StepRepository => throw new NotImplementedException();

        public IRepository<ApplicableIngredient> ApplicableIngredientRepository => throw new NotImplementedException();

        public IRepository<AppliedIngredient> AppliedIngredientRepository => throw new NotImplementedException();

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
