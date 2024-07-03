﻿using System;
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
        /// <param name="pageSize">Page size.</param>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<T>?> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an entity.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<T?> CreateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
