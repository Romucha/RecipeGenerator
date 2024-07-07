using RecipeGenerator.Database.Repositories;
using RecipeGenerator.DTO.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.AppliedIngredients.Requests;
using RecipeGenerator.DTO.AppliedIngredients.Responses;
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
    public interface IUnitOfWork
    {
        Task<GetAllApplicableIngredientsResponse> GetAllApplicableIngredientAsync(GetAllApplicableIngredientsRequest request, CancellationToken cancellationToken = default);

        Task<GetApplicableIngredientResponse> GetApplicableIngredientAsync(GetApplicableIngredientRequest request, CancellationToken cancellationToken = default);

        Task<CreateAppliedIndredientResponse> CreateApplicableIndredientAsync(CreateApplicableIngredientRequest request, CancellationToken cancellationToken = default);

        Task<DeleteAppliedIngredientResponse> DeleteApplicableIngredientAsync(DeleteApplicableIngredientRequest request, CancellationToken cancellationToken = default);

        Task<GetAllAppliedIngredientsResponse> GetAllAppliedIngredientAsync(GetAllAppliedIngredientsRequest request, CancellationToken cancellationToken = default);

        Task<GetAppliedIngredientResponse> GetAppliedIngredientAsync(GetAppliedIngredientRequest request, CancellationToken cancellationToken = default);

        Task<CreateAppliedIndredientResponse> CreateAppliedIndredientAsync(CreateAppliedIngredientRequest request, CancellationToken cancellationToken = default);

        Task<DeleteAppliedIngredientResponse> DeleteAppliedIngredientAsync(DeleteAppliedIngredientRequest request, CancellationToken cancellationToken = default);

        Task<GetAllStepsResponse> GetAllStepAsync(GetAllStepsRequest request, CancellationToken cancellationToken = default);

        Task<GetStepResponse> GetStepAsync(GetStepRequest request, CancellationToken cancellationToken = default);

        Task<CreateAppliedIndredientResponse> CreateApplicableIndredientAsync(CreateStepRequest request, CancellationToken cancellationToken = default);

        Task<DeleteStepResponse> DeleteStepAsync(DeleteStepRequest request, CancellationToken cancellationToken = default);

        Task<GetAllRecipesResponse> GetAllRecipeAsync(GetAllRecipesRequest request, CancellationToken cancellationToken = default);

        Task<GetRecipeResponse> GetRecipeAsync(GetRecipeRequest request, CancellationToken cancellationToken = default);

        Task<CreateAppliedIndredientResponse> CreateApplicableIndredientAsync(CreateRecipeRequest request, CancellationToken cancellationToken = default);

        Task<DeleteRecipeResponse> DeleteRecipeAsync(DeleteRecipeRequest request, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
