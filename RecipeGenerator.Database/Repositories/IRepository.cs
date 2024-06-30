using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    /// <summary>
    /// Provides methods for working with database entities.
    /// </summary>
    /// <typeparam name="T">A database entity.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets a list of entities.
        /// </summary>
        /// <typeparam name="GetAllRequest">Request with filtration and pagination.</typeparam>
        /// <typeparam name="GetAllResponse">Response containing list of entities.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<GetAllResponse> GetAllAsync<GetAllRequest, GetAllResponse>(GetAllRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <typeparam name="GetRequest">Request with identifier.</typeparam>
        /// <typeparam name="GetResponse">Response containing entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<GetResponse> GetAsync<GetRequest, GetResponse>(GetRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an entity.
        /// </summary>
        /// <typeparam name="CreateRequest">Request with parameters required to create an entity.</typeparam>
        /// <typeparam name="CreateResponse">Response containing a new entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<CreateResponse> CreateAsync<CreateRequest, CreateResponse>(CreateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <typeparam name="DeleteRequest">Request with parameters required to delete an entity.</typeparam>
        /// <typeparam name="DeleteResponse">Response containing information about deleted entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<DeleteResponse> DeleteAsync<DeleteRequest, DeleteResponse>(DeleteRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <typeparam name="UpdateRequest">Request with parameters required to update an entity.</typeparam>
        /// <typeparam name="UpdateResponse">Response containing updated entity.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<UpdateResponse> UpdateAsync<UpdateRequest, UpdateResponse>(UpdateRequest request, CancellationToken cancellationToken = default);
    }
}
