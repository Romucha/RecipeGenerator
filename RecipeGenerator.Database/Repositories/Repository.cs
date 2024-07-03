using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly ILogger<Repository<T>> logger;

        public Repository(RecipeGeneratorDbContext dbContext, ILogger<Repository<T>> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<T?> CreateAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                try
                {
                    logger.LogInformation($"Creating entity of type \"{typeof(T).Name}\"...");
                    T entity = (T)Activator.CreateInstance(typeof(T), [])!;

                    dbContext.Add(entity);

                    return entity;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, nameof(CreateAsync));
                    return default;
                }
                finally
                {
                    logger.LogError("Done.");
                }
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                try
                {
                    logger.LogInformation($"Deleting entity of type \"{typeof(T).Name}\"...");

                    var obj = dbContext.Find<T>(id);
                    if (obj != null)
                    {
                        T entity = (obj as T)!;
                        if (entity != null)
                        {
                            dbContext.Remove(entity);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, nameof(DeleteAsync));
                }
                finally
                {
                    logger.LogError("Done.");
                }
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>?> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                try
                {
                    logger.LogInformation($"Getting entities of type \"{typeof(T).Name}\"...");
                    var entities = dbContext
                        .Set<T>()
                        .Skip(pageSize * pageNumber)
                        .Take(pageSize)
                        .AsNoTracking();

                    return entities;

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, nameof(GetAllAsync));
                    return default;
                }
                finally
                {
                    logger.LogError("Done.");
                }
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                try
                {
                    logger.LogInformation($"Getting entity of type \"{typeof(T).Name}\"...");
                    var entity = dbContext.Find<T>(id);

                    return entity;

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, nameof(CreateAsync));
                    return default;
                }
                finally
                {
                    logger.LogError("Done.");
                }
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                try
                {
                    logger.LogInformation($"Getting entity of type \"{typeof(T).Name}\"...");
                    dbContext.Entry(entity).State = EntityState.Modified;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, nameof(CreateAsync));
                }
                finally
                {
                    logger.LogError("Done.");
                }
            }, cancellationToken);
        }
    }
}
