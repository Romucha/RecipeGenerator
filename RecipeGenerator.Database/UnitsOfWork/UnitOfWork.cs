using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
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
        private readonly ILogger<UnitOfWork> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IRepository<Recipe> recipeRepository;
        private readonly IRepository<Step> stepRepostiry;
        private readonly IRepository<AppliedIngredient> appliedIngredientRepository;
        private readonly IRepository<AppliedIngredient> applicableIngredientRepository;

        public UnitOfWork(
            ILogger<UnitOfWork> logger, 
            RecipeGeneratorDbContext dbContext, 
            IRepository<Recipe> recipeRepository,
            IRepository<Step> stepRepostiry,
            IRepository<AppliedIngredient> appliedIngredientRepository,
            IRepository<AppliedIngredient> applicableIngredientRepository)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.recipeRepository = recipeRepository;
            this.stepRepostiry = stepRepostiry;
            this.appliedIngredientRepository = appliedIngredientRepository;
            this.applicableIngredientRepository = applicableIngredientRepository;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
