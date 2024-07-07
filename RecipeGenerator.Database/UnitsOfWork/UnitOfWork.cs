using AutoMapper;
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
    /// <summary>
    /// Provides methods for work with database in a single context.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IRepository<Recipe> recipeRepository;
        private readonly IRepository<Step> stepRepostiry;
        private readonly IRepository<AppliedIngredient> appliedIngredientRepository;
        private readonly IRepository<ApplicableIngredient> applicableIngredientRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Creates a new instanse of <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="dbContext">Database context.</param>
        /// <param name="recipeRepository">Repository of recipes.</param>
        /// <param name="stepRepostiry">Repository of steps.</param>
        /// <param name="appliedIngredientRepository">Repository of applied ingredients.</param>
        /// <param name="applicableIngredientRepository">Repository of applicable ingredients.</param>
        /// <param name="mapper">Mapper.</param>
        public UnitOfWork(
            ILogger<UnitOfWork> logger, 
            RecipeGeneratorDbContext dbContext, 
            IRepository<Recipe> recipeRepository,
            IRepository<Step> stepRepostiry,
            IRepository<AppliedIngredient> appliedIngredientRepository,
            IRepository<ApplicableIngredient> applicableIngredientRepository, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.recipeRepository = recipeRepository;
            this.stepRepostiry = stepRepostiry;
            this.appliedIngredientRepository = appliedIngredientRepository;
            this.applicableIngredientRepository = applicableIngredientRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public Task<CreateAppliedIndredientResponse> CreateApplicableIndredientAsync(CreateApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CreateAppliedIndredientResponse> CreateAppliedIndredientAsync(CreateAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CreateAppliedIndredientResponse> CreateRecipeAsync(CreateRecipeRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CreateAppliedIndredientResponse> CreateStepAsync(CreateStepRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<DeleteAppliedIngredientResponse> DeleteApplicableIngredientAsync(DeleteApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<DeleteAppliedIngredientResponse> DeleteAppliedIngredientAsync(DeleteAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<DeleteRecipeResponse> DeleteRecipeAsync(DeleteRecipeRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<DeleteStepResponse> DeleteStepAsync(DeleteStepRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetAllApplicableIngredientsResponse> GetAllApplicableIngredientAsync(GetAllApplicableIngredientsRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetAllAppliedIngredientsResponse> GetAllAppliedIngredientAsync(GetAllAppliedIngredientsRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetAllRecipesResponse> GetAllRecipeAsync(GetAllRecipesRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetAllStepsResponse> GetAllStepAsync(GetAllStepsRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetApplicableIngredientResponse> GetApplicableIngredientAsync(GetApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetAppliedIngredientResponse> GetAppliedIngredientAsync(GetAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetRecipeResponse> GetRecipeAsync(GetRecipeRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetStepResponse> GetStepAsync(GetStepRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
