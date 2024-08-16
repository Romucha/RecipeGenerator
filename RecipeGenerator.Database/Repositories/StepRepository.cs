using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    public class StepRepository
    {
        private readonly ILogger<RecipeRepository> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IMapper mapper;

        public StepRepository(ILogger<RecipeRepository> logger, RecipeGeneratorDbContext dbContext, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CreateStepResponse> CreateAsync(Guid recipeId, CancellationToken cancellationToken = default)
        {
            try
            {
                Step step = new();
                step.RecipeId = recipeId;
                await dbContext.Steps.AddAsync(step, cancellationToken);
                CreateStepResponse response = mapper.Map<CreateStepResponse>(step);

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                throw;
            }
        }

        public async Task<GetStepResponse> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var recipe = await dbContext.Recipes.FindAsync(id, cancellationToken);
                GetRecipeResponse response = mapper.Map<GetRecipeResponse>(recipe);

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAsync));
                throw;
            }
        }

        public async Task<GetAllRecipesResponse> GetAllAsync(int pageSize, int pageNumber, string? filterString, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<Recipe>? recipes = dbContext.Recipes.AsNoTracking();
                if (!string.IsNullOrEmpty(filterString))
                {
                    recipes = recipes
                        .Where(c => c.Name.IndexOf(filterString, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                if (pageSize > 0)
                {
                    recipes = recipes
                        .Skip(pageSize * pageNumber)
                        .Take(pageSize);
                }

                return await Task.FromResult(new GetAllRecipesResponse()
                {
                    Items = recipes.Select(mapper.Map<GetAllRecipesResponseItem>).OrderByDescending(c => c.UpdatedAt)
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllAsync));
                throw;
            }
        }

        public async Task<DeleteRecipeResponse> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var recipe = await dbContext.Recipes.FindAsync(id, cancellationToken);
                if (recipe != null)
                {

                    DeleteRecipeResponse response = mapper.Map<DeleteRecipeResponse>(recipe);

                    dbContext.Recipes.Remove(recipe);

                    return response;
                }
                else
                {
                    throw new Exception($"Recipe {id} was not found.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAsync));
                throw;
            }
        }

        public async Task<UpdateRecipeResponse> UpdateAsync(
            Guid id,
            string? name,
            string? description,
            byte[]? image,
            Course? course,
            TimeSpan? estimatedTime,
            int? portions,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var recipe = await dbContext.Recipes.FindAsync(id, cancellationToken);
                if (recipe != null)
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        recipe.Name = name;
                    }

                    if (!string.IsNullOrEmpty(description))
                    {
                        recipe.Description = description;
                    }

                    if (image != null)
                    {
                        recipe.Image = image;
                    }

                    if (course != null)
                    {
                        recipe.CourseType = (Course)course;
                    }

                    if (estimatedTime != null)
                    {
                        recipe.EstimatedTime = (TimeSpan)estimatedTime;
                    }

                    if (portions != null)
                    {
                        recipe.Portions = (int)portions;
                    }

                    dbContext.Recipes.Entry(recipe).State = EntityState.Modified;

                    return mapper.Map<UpdateRecipeResponse>(recipe);
                }
                else
                {
                    throw new Exception($"Recipe {id} was not found.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAsync));
                throw;
            }
        }
    }
}
