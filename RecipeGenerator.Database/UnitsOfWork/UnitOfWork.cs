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
        public async Task<CreateApplicableIndredientResponse?> CreateApplicableIndredientAsync(CreateApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Creating applicable ingredient...");
                var ingredient = await applicableIngredientRepository.CreateAsync(cancellationToken);

                return mapper.Map<CreateApplicableIndredientResponse>(ingredient);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateApplicableIndredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<CreateAppliedIndredientResponse?> CreateAppliedIndredientAsync(CreateAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Creating applied ingredient...");
                var ingredient = await appliedIngredientRepository.CreateAsync(cancellationToken);

                return mapper.Map<CreateAppliedIndredientResponse>(ingredient);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAppliedIndredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<CreateRecipeResponse?> CreateRecipeAsync(CreateRecipeRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Creating recipe...");
                var ingredient = await recipeRepository.CreateAsync(cancellationToken);

                return mapper.Map<CreateRecipeResponse>(ingredient);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateRecipeAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<CreateStepResponse?> CreateStepAsync(CreateStepRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Creating step...");
                var ingredient = await recipeRepository.CreateAsync(cancellationToken);

                return mapper.Map<CreateStepResponse>(ingredient);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateStepAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<DeleteApplicableIngredientResponse?> DeleteApplicableIngredientAsync(DeleteApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Deleting applicable ingredient...");
                var ingredient = await applicableIngredientRepository.GetAsync(request.Id, cancellationToken);
                await applicableIngredientRepository.DeleteAsync(request.Id, cancellationToken);

                return mapper.Map<DeleteApplicableIngredientResponse>(ingredient);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteApplicableIngredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<DeleteAppliedIngredientResponse?> DeleteAppliedIngredientAsync(DeleteAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Deleting applicable ingredient...");
                var ingredient = await appliedIngredientRepository.GetAsync(request.Id, cancellationToken);
                await appliedIngredientRepository.DeleteAsync(request.Id, cancellationToken);

                return mapper.Map<DeleteAppliedIngredientResponse>(ingredient);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAppliedIngredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<DeleteRecipeResponse?> DeleteRecipeAsync(DeleteRecipeRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Deleting recipe...");
                var recipe = await recipeRepository.GetAsync(request.Id, cancellationToken);
                await recipeRepository.DeleteAsync(request.Id, cancellationToken);

                return mapper.Map<DeleteRecipeResponse>(recipe);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteRecipeAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<DeleteStepResponse?> DeleteStepAsync(DeleteStepRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Deleting step...");
                var step = await stepRepostiry.GetAsync(request.Id, cancellationToken);
                await stepRepostiry.DeleteAsync(request.Id, cancellationToken);

                return mapper.Map<DeleteStepResponse>(step);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteStepAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<GetAllApplicableIngredientsResponse?> GetAllApplicableIngredientAsync(GetAllApplicableIngredientsRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting applicable ingredients...");
                var entites = await applicableIngredientRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);
                List<ApplicableIngredient> fitleredEntities = new();
                if (entites != null)
                {
                    fitleredEntities.AddRange(entites.Where(c =>
                        c.Name.Contains(request.Filter, StringComparison.OrdinalIgnoreCase)
                        || c.Description.Contains(request.Filter, StringComparison.OrdinalIgnoreCase)));
                }

                return new()
                {
                    Items = fitleredEntities.Select(mapper.Map<GetAllApplicableIngredientResponse>),
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllApplicableIngredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<GetAllAppliedIngredientsResponse?> GetAllAppliedIngredientAsync(GetAllAppliedIngredientsRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting applied ingredients...");
                var entites = await appliedIngredientRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);
                List<AppliedIngredient> fitleredEntities = new();
                if (entites != null)
                {
                    fitleredEntities.AddRange(entites.Where(c => 
                        c.Ingredient is null ? false : 
                            (c.Ingredient.Name.Contains(request.Filter, StringComparison.OrdinalIgnoreCase)
                            || c.Ingredient.Description.Contains(request.Filter, StringComparison.OrdinalIgnoreCase))));
                }

                return new()
                {
                    Items = fitleredEntities.Select(mapper.Map<GetAllAppliedIngredientResponse>),
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllAppliedIngredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<GetAllRecipesResponse?> GetAllRecipeAsync(GetAllRecipesRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting recipes...");
                var entites = await recipeRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);
                List<Recipe> fitleredEntities = new();
                if (entites != null)
                {
                    fitleredEntities.AddRange(entites.Where(c =>
                        c.Name.Contains(request.Filter, StringComparison.OrdinalIgnoreCase)
                        || c.Description.Contains(request.Filter, StringComparison.OrdinalIgnoreCase)));
                }

                return new()
                {
                    Items = fitleredEntities.Select(mapper.Map<GetAllRecipeResponse>),
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllRecipeAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<GetAllStepsResponse?> GetAllStepsAsync(GetAllStepsRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting steps...");
                var entites = await stepRepostiry.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);
                List<Step> fitleredEntities = new();
                if (entites != null)
                {
                    fitleredEntities.AddRange(entites.Where(c => 
                        c.Name.Contains(request.Filter, StringComparison.OrdinalIgnoreCase)
                        || c.Description.Contains(request.Filter, StringComparison.OrdinalIgnoreCase)));
                }

                return new()
                {
                    Items = fitleredEntities.Select(mapper.Map<GetAllStepResponse>),
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllStepsAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<GetApplicableIngredientResponse?> GetApplicableIngredientAsync(GetApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting applicable ingredient...");
                var entity = await applicableIngredientRepository.GetAsync(request.Id, cancellationToken);
                
                return mapper.Map<GetApplicableIngredientResponse>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllApplicableIngredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<GetAppliedIngredientResponse?> GetAppliedIngredientAsync(GetAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting applied ingredient...");
                var entity = await appliedIngredientRepository.GetAsync(request.Id, cancellationToken);

                return mapper.Map<GetAppliedIngredientResponse>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAppliedIngredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<GetRecipeResponse?> GetRecipeAsync(GetRecipeRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting recipe...");
                var entity = await recipeRepository.GetAsync(request.Id, cancellationToken);

                return mapper.Map<GetRecipeResponse>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetRecipeAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<GetStepResponse?> GetStepAsync(GetStepRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Getting step...");
                var entity = await stepRepostiry.GetAsync(request.Id, cancellationToken);

                return mapper.Map<GetStepResponse>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAppliedIngredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<UpdateApplicableIngredientResponse?> UpdateApplicableIngredientAsync(UpdateApplicableIngredientRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Updating applicable ingredient...");
                var entity = await applicableIngredientRepository.GetAsync(request.Id, cancellationToken);
                if (entity is null)
                    return null;

                if (request.Description is not null)
                    entity.Description = request.Description;

                if (request.Image is not null)
                    entity.Image = request.Image;

                if (request.IngredientType is not null)
                    entity.IngredientType = (IngredientType)request.IngredientType;

                if (request.Link is not null)
                    entity.Link = request.Link;

                if (request.Name is not null)
                    entity.Name = request.Name;



                await applicableIngredientRepository.UpdateAsync(entity, cancellationToken);

                return mapper.Map<UpdateApplicableIngredientResponse>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(UpdateApplicableIngredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<UpdateAppliedIngredientResponse?> UpdateAppliedIngredientAsync(UpdateAppliedIngredientRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Updating applied ingredient...");
                var entity = await appliedIngredientRepository.GetAsync(request.Id, cancellationToken);

                if (entity is null)
                    return null;

                if (request.IngredientId is not null)
                    entity.IngredientId = (Guid)request.IngredientId;

                if (request.RecipeId is not null)
                    entity.RecipeId = (Guid)request.RecipeId;

                await appliedIngredientRepository.UpdateAsync(entity, cancellationToken);

                return mapper.Map<UpdateAppliedIngredientResponse>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(UpdateAppliedIngredientAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<UpdateRecipeResponse?> UpdateRecipeAsync(UpdateRecipeRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Updating recipe...");
                var entity = await recipeRepository.GetAsync(request.Id, cancellationToken);

                if (entity is null)
                    return null;

                if (request.CourseType is not null)
                    entity.CourseType = (Course)request.CourseType;

                if (request.Description is not null)
                    entity.Description = request.Description;

                if (request.EstimatedTime is not null)
                    entity.EstimatedTime = (TimeSpan)request.EstimatedTime;

                if (request.Image is not null)
                    entity.Image = request.Image;

                if (request.Ingredients is not null)
                    entity.Ingredients = request.Ingredients.Select(mapper.Map<AppliedIngredient>).ToList();

                if (request.Name is not null)
                    entity.Name = request.Name;

                if (request.Portions is not null)
                    entity.Portions = (int)request.Portions;

                if (request.Steps is not null)
                    entity.Steps = request.Steps.Select(mapper.Map<Step>).ToList();

                await recipeRepository.UpdateAsync(entity, cancellationToken);

                return mapper.Map<UpdateRecipeResponse>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(UpdateRecipeAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<UpdateStepResponse?> UpdateStepAsync(UpdateStepRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Updating step...");
                var entity = await stepRepostiry.GetAsync(request.Id, cancellationToken);

                if (entity is null)
                    return null;

                if (request.Index is not null)
                    entity.Index = (int)request.Index;

                if (request.Name is not null)
                    entity.Name = request.Name;

                if (request.Photos is not null)
                    entity.Photos = request.Photos;

                if (request.RecipeId is not null)
                    entity.RecipeId = (Guid)request.RecipeId;

                await stepRepostiry.UpdateAsync(entity, cancellationToken);

                return mapper.Map<UpdateStepResponse>(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(UpdateStepAsync));
                return null;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
