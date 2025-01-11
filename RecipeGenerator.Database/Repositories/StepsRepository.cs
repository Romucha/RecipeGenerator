using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.DTO.Steps.Responses;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    public class StepsRepository
    {
        private readonly ILogger<StepsRepository> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IMapper mapper;

        public StepsRepository(ILogger<StepsRepository> logger, RecipeGeneratorDbContext dbContext, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CreateStepResponse?> CreateAsync(int recipeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var recipe = await dbContext.Recipes.FindAsync(recipeId, cancellationToken);
                if (recipe is null)
                    return null;
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

        public async Task<GetStepResponse?> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var step = await dbContext.Steps.FindAsync(id, cancellationToken);
                if (step != null)
                {
                    GetStepResponse response = mapper.Map<GetStepResponse>(step);

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

        public async Task<GetAllStepsResponse> GetAllAsync(int recipeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var recipe = await dbContext.Recipes.FindAsync(recipeId, cancellationToken);
                if (recipe is null)
                    return new()
                    {
                        TotalCount = 0,
                        Items = Enumerable.Empty<GetAllStepsResponseItem>(),
                        PageNumber = 1,
                        PageSize = 0
                    };
                var steps = recipe.Steps;
                return await Task.FromResult(new GetAllStepsResponse()
                {
                    TotalCount = steps.Count,
                    Items = steps.Select(mapper.Map<GetAllStepsResponseItem>).OrderBy(c => c.Index),
                    PageNumber = 1,
                    PageSize = steps.Count
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllAsync));
                throw;
            }
        }

        public async Task<DeleteStepResponse?> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var step = await dbContext.Steps.FindAsync(id, cancellationToken);
                if (step != null)
                {

                    DeleteStepResponse response = mapper.Map<DeleteStepResponse>(step);

                    dbContext.Steps.Remove(step);

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

        public async Task<UpdateStepResponse?> UpdateAsync(
            int id,
            string? name,
            string? description,
            List<byte[]>? photos,
            int? index,
            int? recipeId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var step = await dbContext.Steps.FindAsync(id, cancellationToken);
                if (step == null)
                {
                    step = new();
                    await dbContext.Steps.AddAsync(step);
                }
                if (!string.IsNullOrEmpty(name))
                {
                    step.Name = name;
                }

                if (!string.IsNullOrEmpty(description))
                {
                    step.Description = description;
                }

                if (photos != null)
                {
                    step.Photos = photos;
                }

                if (index != null)
                {
                    step.Index = (int)index;
                }

                if (recipeId != null)
                {
                    step.RecipeId = recipeId;
                }

                step.UpdatedAt = DateTime.UtcNow;

                return mapper.Map<UpdateStepResponse>(step);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAsync));
                throw;
            }
        }
    }
}
