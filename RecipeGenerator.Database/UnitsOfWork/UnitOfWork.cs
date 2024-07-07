using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.DTO.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.AppliedIngredients.Requests;
using RecipeGenerator.DTO.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Recipes.Requests;
using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.DTO.Steps.Requests;
using RecipeGenerator.DTO.Steps.Responses;
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

        public Task<CreateAppliedIndredientResponse> CreateApplicableIndredientAsync(CreateApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<CreateAppliedIndredientResponse> CreateApplicableIndredientAsync(CreateStepRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<CreateAppliedIndredientResponse> CreateApplicableIndredientAsync(CreateRecipeRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<CreateAppliedIndredientResponse> CreateAppliedIndredientAsync(CreateAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteAppliedIngredientResponse> DeleteApplicableIngredientAsync(DeleteApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteAppliedIngredientResponse> DeleteAppliedIngredientAsync(DeleteAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteRecipeResponse> DeleteRecipeAsync(DeleteRecipeRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteStepResponse> DeleteStepAsync(DeleteStepRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllApplicableIngredientsResponse> GetAllApplicableIngredientAsync(GetAllApplicableIngredientsRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllAppliedIngredientsResponse> GetAllAppliedIngredientAsync(GetAllAppliedIngredientsRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllRecipesResponse> GetAllRecipeAsync(GetAllRecipesRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllStepsResponse> GetAllStepAsync(GetAllStepsRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetApplicableIngredientResponse> GetApplicableIngredientAsync(GetApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetAppliedIngredientResponse> GetAppliedIngredientAsync(GetAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetRecipeResponse> GetRecipeAsync(GetRecipeRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GetStepResponse> GetStepAsync(GetStepRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
