﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    public class ApplicableIngredientRepository
    {
        private readonly ILogger<ApplicableIngredientRepository> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IMapper mapper;

        public ApplicableIngredientRepository(ILogger<ApplicableIngredientRepository> logger, RecipeGeneratorDbContext dbContext, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CreateApplicableIndredientResponse> CreateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                ApplicableIngredient ingredient = new();
                await dbContext.ApplicableIngredients.AddAsync(ingredient, cancellationToken);
                CreateApplicableIndredientResponse response = mapper.Map<CreateApplicableIndredientResponse>(ingredient);

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                throw;
            }
        }

        public async Task<GetAllApplicableIngredientsResponseItem> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var ingredient = await dbContext.ApplicableIngredients.FindAsync(id, cancellationToken);
                GetAllApplicableIngredientsResponseItem response = mapper.Map<GetAllApplicableIngredientsResponseItem>(ingredient);

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAsync));
                throw;
            }
        }

        public async Task<GetAllApplicableIngredientsResponse> GetAllAsync(int pageSize, int pageNumber, string? filterString, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<ApplicableIngredient>? ingredients = dbContext.ApplicableIngredients.AsNoTracking();
                if (!string.IsNullOrEmpty(filterString))
                {
                    ingredients = ingredients
                        .Where(c => c.Name.IndexOf(filterString, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                if (pageSize > 0)
                {
                    ingredients = ingredients
                        .Skip(pageSize * pageNumber)
                        .Take(pageSize);
                }

                return await Task.FromResult(new GetAllApplicableIngredientsResponse()
                {
                    TotalCount = ingredients.Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Items = ingredients.Select(mapper.Map<GetAllApplicableIngredientsResponseItem>).OrderBy(c => c.Name)
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllAsync));
                throw;
            }
        }

        public async Task<DeleteApplicableIngredientResponse> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var ingredient = await dbContext.ApplicableIngredients.FindAsync(id, cancellationToken);
                if (ingredient != null)
                {

                    DeleteApplicableIngredientResponse response = mapper.Map<DeleteApplicableIngredientResponse>(ingredient);

                    dbContext.ApplicableIngredients.Remove(ingredient);

                    return response;
                }
                else
                {
                    throw new Exception($"Applicable ingredient {id} was not found.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAsync));
                throw;
            }
        }

        public async Task<UpdateApplicableIngredientResponse> UpdateAsync(
            Guid id,
            string? name,
            string? description,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var ingredient = await dbContext.ApplicableIngredients.FindAsync(id, cancellationToken);
                if (ingredient != null)
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        ingredient.Name = name;
                    }

                    if (!string.IsNullOrEmpty(description))
                    {
                        ingredient.Description = description;
                    }

                    ingredient.UpdatedAt = DateTime.UtcNow;
                    dbContext.ApplicableIngredients.Entry(ingredient).State = EntityState.Modified;

                    return mapper.Map<UpdateApplicableIngredientResponse>(ingredient);
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
