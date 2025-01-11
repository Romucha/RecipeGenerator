using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.DTO.AppliedIngredients.Responses;
using RecipeGenerator.DTO.AppliedIngredients.Requests;
using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.DTO.Steps.Responses;

namespace RecipeGenerator.Database.Repositories
{
    public class AppliedIngredientsRepository
    {
        private readonly ILogger<AppliedIngredientsRepository> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IMapper mapper;

        public AppliedIngredientsRepository(ILogger<AppliedIngredientsRepository> logger, RecipeGeneratorDbContext dbContext, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CreateAppliedIndredientResponse> CreateAsync(int recipeId, int applicableIngredientId, CancellationToken cancellationToken = default)
        {
            try
            {
                var recipe = await dbContext.Recipes.FindAsync(recipeId);
                if (recipe is null)
                    throw new Exception($"Recipe {recipeId} was not found");

                var applicableIngredient = await dbContext.ApplicableIngredients.FindAsync(applicableIngredientId);
                if (applicableIngredient is null)
                    throw new Exception($"Ingredient {applicableIngredientId} was not found");

                AppliedIngredient ingredient = new();
                ingredient.RecipeId = recipeId;
                ingredient.IngredientId = applicableIngredientId;
                ingredient.Name = applicableIngredient.Name;
                ingredient.Description = applicableIngredient.Description;
                await dbContext.AppliedIngredients.AddAsync(ingredient, cancellationToken);
                CreateAppliedIndredientResponse response = mapper.Map<CreateAppliedIndredientResponse>(ingredient);

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                throw;
            }
        }

        public async Task<GetAppliedIngredientResponse?> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var ingredient = await dbContext.AppliedIngredients.FindAsync(id, cancellationToken);
                if (ingredient is not null)
                {
                    GetAppliedIngredientResponse response = mapper.Map<GetAppliedIngredientResponse>(ingredient);

                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAsync));
                throw;
            }
        }

        public async Task<GetAllAppliedIngredientsResponse> GetAllAsync(int recipeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var recipe = await dbContext.Recipes.FindAsync(recipeId, cancellationToken);
                if (recipe is null)
                    return new()
                    {
                        TotalCount = 0,
                        Items = Enumerable.Empty<GetAllAppliedIngredientsResponseItem>(),
                        PageNumber = 1,
                        PageSize = 0
                    };
                var ingredients = recipe.Ingredients;
                return await Task.FromResult(new GetAllAppliedIngredientsResponse()
                {
                    TotalCount = ingredients.Count,
                    Items = ingredients.Select(mapper.Map<GetAllAppliedIngredientsResponseItem>).OrderBy(c => c.Name),
                    PageNumber = 1,
                    PageSize = ingredients.Count
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllAsync));
                throw;
            }
        }

        public async Task<DeleteAppliedIngredientResponse?> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var ingredient = await dbContext.AppliedIngredients.FindAsync(id, cancellationToken);
                if (ingredient != null)
                {

                    DeleteAppliedIngredientResponse response = mapper.Map<DeleteAppliedIngredientResponse>(ingredient);

                    dbContext.AppliedIngredients.Remove(ingredient);

                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAsync));
                throw;
            }
        }

        public async Task<UpdateAppliedIngredientResponse?> UpdateAsync(
            int id,
            string? name,
            string? description,
            int? recipeId,
            int? ingredientId,
            int? measurementId,
            double? measurementValue,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var ingredient = await dbContext.AppliedIngredients.FindAsync(id, cancellationToken);
                if (ingredient == null)
                {
                    ingredient = new();
                    await dbContext.AppliedIngredients.AddAsync(ingredient);
                }
                if (!string.IsNullOrEmpty(name))
                {
                    ingredient.Name = name;
                }

                if (!string.IsNullOrEmpty(description))
                {
                    ingredient.Description = description;
                }

                if (recipeId != null)
                {
                    ingredient.RecipeId = recipeId;
                }

                if (ingredientId != null)
                {
                    ingredient.IngredientId = ingredientId;
                }

                if (measurementId != null)
                {
                    ingredient.MeasurementId = measurementId;
                }

                if (measurementValue != null)
                {
                    ingredient.MeasurementValue = (double)measurementValue;
                }

                ingredient.UpdatedAt = DateTime.UtcNow;

                return mapper.Map<UpdateAppliedIngredientResponse>(ingredient);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAsync));
                throw;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            try
            {
                return await dbContext.AppliedIngredients.AnyAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString(), nameof(ExistsAsync));
                return false;
            }
        }
    }
}
