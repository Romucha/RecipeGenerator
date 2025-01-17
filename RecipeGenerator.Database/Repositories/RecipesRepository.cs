﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    public class RecipesRepository
    {
        private readonly ILogger<RecipesRepository> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IMapper mapper;

        public RecipesRepository(ILogger<RecipesRepository> logger, RecipeGeneratorDbContext dbContext, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CreateRecipeResponse> CreateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                Recipe recipe = new();
                await dbContext.Recipes.AddAsync(recipe, cancellationToken);
                CreateRecipeResponse response = mapper.Map<CreateRecipeResponse>(recipe);

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                throw;
            }
        }

        public async Task<GetRecipeResponse?> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var recipe = await dbContext.Recipes.FindAsync(id, cancellationToken);
                if (recipe != null)
                {
                    GetRecipeResponse response = mapper.Map<GetRecipeResponse>(recipe);

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

        public async Task<GetAllRecipesResponse> GetAllAsync(int pageSize, int pageNumber, string? filterString, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<Recipe>? recipes = dbContext.Recipes.AsNoTracking();
                var totalCount = recipes.Count();
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
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Items = recipes.Select(mapper.Map<GetAllRecipesResponseItem>).OrderByDescending(c => c.UpdatedAt)
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllAsync));
                throw;
            }
        }

        public async Task<DeleteRecipeResponse?> DeleteAsync(int id, CancellationToken cancellationToken = default)
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
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAsync));
                throw;
            }
        }

        public async Task<UpdateRecipeResponse?> UpdateAsync(
            int id, 
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

                    recipe.UpdatedAt = DateTime.UtcNow;
                    dbContext.Recipes.Entry(recipe).State = EntityState.Modified;

                    return mapper.Map<UpdateRecipeResponse>(recipe);
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
    }
}
