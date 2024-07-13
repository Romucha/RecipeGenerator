using RecipeGenerator.Database.Repositories;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Implementations.Recipes.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
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
    /// Provides singatures of methods for work for with database in a single context.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets a list of applicable ingredients.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<GetAllApplicableIngredientsResponse?> GetAllApplicableIngredientAsync(GetAllApplicableIngredientsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an applicable ingredient.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<GetApplicableIngredientResponse?> GetApplicableIngredientAsync(GetApplicableIngredientRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an applicable ingredient.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<CreateApplicableIndredientResponse?> CreateApplicableIndredientAsync(CreateApplicableIngredientRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an applicable ingredient.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<DeleteApplicableIngredientResponse?> DeleteApplicableIngredientAsync(DeleteApplicableIngredientRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an applicable ingredient.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<UpdateApplicableIngredientResponse?> UpdateApplicableIngredientAsync(UpdateApplicableIngredientRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of applied ingredients.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<GetAllAppliedIngredientsResponse?> GetAllAppliedIngredientAsync(GetAllAppliedIngredientsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an applied ingredient.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<GetAppliedIngredientResponse?> GetAppliedIngredientAsync(GetAppliedIngredientRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an applied ingredient.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<CreateAppliedIndredientResponse?> CreateAppliedIndredientAsync(CreateAppliedIngredientRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an applied ingredient.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<DeleteAppliedIngredientResponse?> DeleteAppliedIngredientAsync(DeleteAppliedIngredientRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an applied ingredient.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<UpdateAppliedIngredientResponse?> UpdateAppliedIngredientAsync(UpdateAppliedIngredientRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of steps.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<GetAllStepsResponse?> GetAllStepsAsync(GetAllStepsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a step.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<GetStepResponse?> GetStepAsync(GetStepRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a step.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<CreateStepResponse?> CreateStepAsync(CreateStepRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a step.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<DeleteStepResponse?> DeleteStepAsync(DeleteStepRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a step.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<UpdateStepResponse?> UpdateStepAsync(UpdateStepRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of recipes.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<GetAllRecipesResponse?> GetAllRecipeAsync(GetAllRecipesRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a recipe.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<GetRecipeResponse?> GetRecipeAsync(GetRecipeRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a recipe.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<CreateRecipeResponse?> CreateRecipeAsync(CreateRecipeRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a recipe.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<DeleteRecipeResponse?> DeleteRecipeAsync(DeleteRecipeRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a recipe.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<UpdateRecipeResponse?> UpdateRecipeAsync(UpdateRecipeRequest request, CancellationToken cancellationToken= default);

        /// <summary>
        /// Save changes in database.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
