using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.Measurements
{
    public partial class MeasurementsRepositoryTests
    {
        private readonly IMapper mapper;
        public MeasurementsRepositoryTests()
        {
            mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();
        }

        private MeasurementsRepository GetRepository(RecipeGeneratorDbContext context)
        {
            return new MeasurementsRepository(new NullLogger<MeasurementsRepository>(), context, mapper);
        }
    }
}
