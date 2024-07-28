using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Models;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IRecipeGeneratorEntity
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

                    dbContext.Set<T>().Add(entity);

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

                    var obj = dbContext.Set<T>().Find(id);
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
        public async Task<IEnumerable<T>?> GetAllAsync(int pageNumber = 0, int pageSize = 0, string? filterString = "", CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                try
                {
                    logger.LogInformation($"Getting entities of type \"{typeof(T).Name}\"...");
                    IEnumerable<T>? entities = dbContext.Set<T>().AsNoTracking().AsEnumerable();
                    if (!string.IsNullOrEmpty(filterString))
                    {
                        entities = entities
                            .Where(c => c.Name.IndexOf(filterString, StringComparison.OrdinalIgnoreCase) >= 0);
                    }

                    if (pageSize > 0)
                    {
                        entities = entities
                            .Skip(pageSize * pageNumber)
                            .Take(pageSize);
                    }

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
                    T? entity;                    
                    if (typeof(T) == typeof(Recipe))
                    {
                        entity = dbContext.Set<Recipe>().Include(c => c.Ingredients).Include(c => c.Steps).FirstOrDefault(c => c.Id == id) as T;
                    }
                    else
                    {
                        entity = dbContext.Set<T>().Find(id);
                    }

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
                    entity.UpdatedAt = DateTime.UtcNow;
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
