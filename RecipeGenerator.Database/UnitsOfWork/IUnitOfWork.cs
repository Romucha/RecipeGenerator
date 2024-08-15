using RecipeGenerator.DTO.Interfaces.Requests;
using RecipeGenerator.DTO.Interfaces.Responses;
using RecipeGenerator.Models;

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
        Task<Response?> CreateAsync<Entity, Request, Response>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : ICreateRequest
            where Response : ICreateResponse;

        /// <summary>
        /// Deletes a recipe generator entity.
        /// </summary>
        /// <typeparam name="Entity">Recipe generator entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        Task<Response?> DeleteAsync<Entity, Request, Response>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : IDeleteRequest
            where Response : IDeleteResponse;

        /// <summary>
        /// Gets a list of recipe generator entities.
        /// </summary>
        /// <typeparam name="Entity">Recipe generator entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        Task<Response?> GetAllAsync<Entity, Request, Response, ResponseItem>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : IGetAllRequest
            where Response : IGetAllResponse<IGetAllResponseItem>
            where ResponseItem : IGetAllResponseItem;

        /// <summary>
        /// Gets a recipe generator entity.
        /// </summary>
        /// <typeparam name="Entity">Recipe generator entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        Task<Response?> GetAsync<Entity, Request, Response>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : IGetRequest
            where Response : IGetResponse;

        /// <summary>
        /// Updates a recipe generator entity.
        /// </summary>
        /// <typeparam name="Entity">Recipe generator entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response.</returns>
        Task<Response?> UpdateAsync<Entity, Request, Response>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : IUpdateRequest
            where Response : IUpdateResponse;

        /// <summary>
        /// Save changes in database.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
