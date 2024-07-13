using RecipeGenerator.Database.Repositories;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Implementations.Recipes.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
using RecipeGenerator.DTO.Interfaces.Requests;
using RecipeGenerator.DTO.Interfaces.Responses;
using RecipeGenerator.Models;
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
        /// Creates a recipe generator entity.
        /// </summary>
        /// <typeparam name="Entity">Recipe generator entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        Task<ICreateResponse> CreateAsync<Entity>(ICreateRequest request, CancellationToken cancellationToken = default) where Entity : IRecipeGeneratorEntity;

        /// <summary>
        /// Deletes a recipe generator entity.
        /// </summary>
        /// <typeparam name="Entity">Recipe generator entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        Task<IDeleteResponse> DeleteAsync<Entity>(IDeleteRequest request, CancellationToken cancelToken = default) where Entity : IRecipeGeneratorEntity;

        /// <summary>
        /// Gets a list of recipe generator entities.
        /// </summary>
        /// <typeparam name="Entity">Recipe generator entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        Task<IGetAllResponse<IGetAllResponseItem>> GetAllAsync<Entity>(IGetAllRequest request, CancellationToken cancelToken = default) where Entity: IRecipeGeneratorEntity;

        /// <summary>
        /// Gets a recipe generator entity.
        /// </summary>
        /// <typeparam name="Entity">Recipe generator entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        Task<IGetResponse> GetAsync<Entity>(IGetResponse request, CancellationToken cancellationToken = default) where Entity : IRecipeGeneratorEntity;

        /// <summary>
        /// Updates a recipe generator entity.
        /// </summary>
        /// <typeparam name="Entity">Recipe generator entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        Task<IUpdateResponse> UpdateAsync<Entity>(IUpdateResponse request, CancellationToken cancelToken = default) where Entity : IRecipeGeneratorEntity;

        /// <summary>
        /// Save changes in database.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
