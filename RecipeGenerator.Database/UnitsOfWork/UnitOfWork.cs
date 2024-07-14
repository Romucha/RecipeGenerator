using AutoMapper;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
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
using System.Reflection;
using System.Text;
using System.Threading;
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
        private GenericDictionary repositories;
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
            repositories = new();
            repositories.Add(typeof(Recipe), recipeRepository);
            repositories.Add(typeof(Step), stepRepostiry);
            repositories.Add(typeof(AppliedIngredient), appliedIngredientRepository);
            repositories.Add(typeof(ApplicableIngredient), applicableIngredientRepository);
            
            this.mapper = mapper;
        }

        private object? getValue(object src, string propName)
        {
            var prop = src.GetType().GetProperty(propName);
            if (prop == null)
                return default;

            var value = prop.GetValue(src, null);

            if (value == null)
                return default;

            return value;
        }


        private void setValue<T>(T obj, string propertyName, object value)
        {
            // these should be cached if possible
            Type type = typeof(T);
            PropertyInfo pi = type.GetProperty(propertyName)!;

            var piType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;

            if (piType.IsEnum)
            {
                object enumValue = Enum.ToObject(piType, value); 
                pi.SetValue(obj, Convert.ChangeType(enumValue, piType), null);
            }
            else
            {
                pi.SetValue(obj, Convert.ChangeType(value, piType), null);
            }
        }

        /// <inheritdoc/>
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        

        public async Task<Response?> CreateAsync<Entity, Request, Response>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : ICreateRequest
            where Response : ICreateResponse
        {
            try
            {
                logger.LogInformation($"Creating {typeof(Entity).Name}...");
                var ingredient = await repositories.GetValue<IRepository<Entity>>(typeof(Entity)).CreateAsync(cancellationToken);

                return mapper.Map<Response>(ingredient);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                return default;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task<Response?> DeleteAsync<Entity, Request, Response>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : IDeleteRequest
            where Response : IDeleteResponse
        {
            try
            {
                logger.LogInformation($"Deleting {typeof(Entity).Name}...");
                var ingredient = await repositories.GetValue<IRepository<Entity>>(typeof(Entity)).GetAsync(request.Id, cancellationToken);
                await repositories.GetValue<IRepository<Entity>>(typeof(Entity)).DeleteAsync(request.Id, cancellationToken);

                return mapper.Map<Response>(ingredient);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAsync));
                return default;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task<Response?> GetAllAsync<Entity, Request, Response, ResponseItem>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : IGetAllRequest
            where Response : IGetAllResponse<IGetAllResponseItem>
            where ResponseItem : IGetAllResponseItem
        {
            try
            {
                logger.LogInformation($"Getting {typeof(Entity).Name}s...");
                var entites = await repositories.GetValue<IRepository<Entity>>(typeof(Entity)).GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);
                List<Entity> fitleredEntities = new();
                if (entites != null)
                {
                    if (string.IsNullOrEmpty(request.Filter))
                    {
                        fitleredEntities.AddRange(entites);
                    }
                    else
                    {
                        fitleredEntities.AddRange(entites.Where(c =>
                        {
                            var name = getValue(c, "Name");
                            if (name == null)
                                return false;
                            var nameValue = name.ToString();
                            if (nameValue == null) 
                                return false;
                            return nameValue.Contains(request.Filter, StringComparison.OrdinalIgnoreCase);
                        }));
                    }
                }

                if (Activator.CreateInstance(typeof(Response)) is not Response response)
                    return default;
                response.Items = fitleredEntities.Select(c => (IGetAllResponseItem)mapper.Map<ResponseItem>(c));
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllAsync));
                return default;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task<Response?> GetAsync<Entity, Request, Response>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : IGetRequest
            where Response : IGetResponse
        {
            try
            {
                logger.LogInformation($"Getting {typeof(Entity)}...");
                var entity = await repositories.GetValue<IRepository<Entity>>(typeof(Entity)).GetAsync(request.Id, cancellationToken);

                return mapper.Map<Response>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAsync));
                return default;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }


        private void editEntity<Request, Entity>(Request request, Entity entity)
        {
            var requestType = request!.GetType();
            var entityType = entity!.GetType();

            foreach (var reqProp in requestType.GetProperties())
            {
                if (reqProp.Name != "Id")
                {
                    var requestPropValue = getValue(request, reqProp.Name);

                    if (requestPropValue != null)
                    {
                        setValue(entity, reqProp.Name, requestPropValue);
                    }
                }
            }
        }

        public async Task<Response?> UpdateAsync<Entity, Request, Response>(Request request, CancellationToken cancellationToken = default)
            where Entity : IRecipeGeneratorEntity
            where Request : IUpdateRequest
            where Response : IUpdateResponse
        {
            try
            {
                logger.LogInformation($"Updating {typeof(Entity).Name}...");
                var entity = await repositories.GetValue<IRepository<Entity>>(typeof(Entity)).GetAsync(request.Id, cancellationToken);
                if (entity == null)
                {
                    return default;
                }

                editEntity(request, entity);

                await repositories.GetValue<IRepository<Entity>>(typeof(Entity)).UpdateAsync(entity, cancellationToken);

                return mapper.Map<Response>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(UpdateAsync));
                return default;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        private class GenericDictionary
        {
            private Dictionary<object, object> _dict = new Dictionary<object, object>();

            public void Add<T>(object key, T value) where T : class
            {
                _dict.Add(key, value);
            }

            public T GetValue<T>(object key) where T : class
            {
                return (_dict[key] as T)!;
            }
        }
    }
}
