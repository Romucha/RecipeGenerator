using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.DTO.Measurements.Responses;
using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    public class MeasurementsRepository
    {
        private readonly ILogger<MeasurementsRepository> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IMapper mapper;

        public MeasurementsRepository(ILogger<MeasurementsRepository> logger, RecipeGeneratorDbContext dbContext, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CreateMeasurementResponse> CreateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                Measurement measurement = new();
                await dbContext.Measurements.AddAsync(measurement, cancellationToken);
                CreateMeasurementResponse response = mapper.Map<CreateMeasurementResponse>(measurement);

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                throw;
            }
        }

        public async Task<GetMeasurementResponse?> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var measurement = await dbContext.Measurements.FindAsync(id, cancellationToken);
                if (measurement != null)
                {
                    GetMeasurementResponse response = mapper.Map<GetMeasurementResponse>(measurement);

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

        public async Task<GetAllMeasurementsResponse> GetAllAsync(int pageSize, int pageNumber, string? filterString, CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<Measurement>? measurements = dbContext.Measurements.AsNoTracking();
                var totalCount = measurements.Count();
                if (!string.IsNullOrEmpty(filterString))
                {
                    measurements = measurements
                        .Where(c => c.Name.IndexOf(filterString, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                if (pageSize > 0)
                {
                    measurements = measurements
                        .Skip(pageSize * pageNumber)
                        .Take(pageSize);
                }

                return await Task.FromResult(new GetAllMeasurementsResponse()
                {
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Items = measurements.Select(mapper.Map<GetAllMeasurementsResponseItem>).OrderByDescending(c => c.UpdatedAt)
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetAllAsync));
                throw;
            }
        }

        public async Task<DeleteMeasurementResponse?> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var measurement = await dbContext.Measurements.FindAsync(id, cancellationToken);
                if (measurement != null)
                {

                    DeleteMeasurementResponse response = mapper.Map<DeleteMeasurementResponse>(measurement);

                    dbContext.Measurements.Remove(measurement);

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
            int? measurementType,
            bool? isBase,
            double? conversionCoefficient,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var measurement = await dbContext.Measurements.FindAsync(id, cancellationToken);
                if (measurement != null)
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        measurement.Name = name;
                    }

                    if (!string.IsNullOrEmpty(description))
                    {
                        measurement.Description = description;
                    }

                    if (measurementType != null)
                    {
                        measurement.MeasurementType = (MeasurementType)measurementType;
                    }

                    if (isBase != null)
                    {
                        measurement.IsBase = (bool)isBase;
                    }

                    if (conversionCoefficient != null)
                    {
                        measurement.ConversionCoefficient = (double)conversionCoefficient;
                    }

                    measurement.UpdatedAt = DateTime.UtcNow;
                    dbContext.Measurements.Entry(measurement).State = EntityState.Modified;

                    return mapper.Map<UpdateRecipeResponse>(measurement);
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
