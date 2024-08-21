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
    public class StepRepository
    {
        private readonly ILogger<StepRepository> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IMapper mapper;

        public StepRepository(ILogger<StepRepository> logger, RecipeGeneratorDbContext dbContext, IMapper mapper)
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

        public async Task<GetStepResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default)
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

        public async Task<GetAllStepsResponse> GetAllAsync(Guid recipeId, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<Step>? steps = dbContext.Steps.AsNoTracking().Where(c => c.RecipeId == recipeId);
                
                return await Task.FromResult(new GetAllStepsResponse()
                {
                    TotalCount = steps.Count(),
                    Items = steps.Select(mapper.Map<GetAllStepsResponseItem>).OrderByDescending(c => c.Index),
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllAsync));
                throw;
            }
        }

        public async Task<DeleteStepResponse?> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
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
            Guid id,
            string? name,
            string? description,
            List<byte[]>? photos,
            int? index,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var step = await dbContext.Steps.FindAsync(id, cancellationToken);
                if (step != null)
                {
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

                    dbContext.Steps.Entry(step).State = EntityState.Modified;

                    return mapper.Map<UpdateStepResponse>(step);
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
