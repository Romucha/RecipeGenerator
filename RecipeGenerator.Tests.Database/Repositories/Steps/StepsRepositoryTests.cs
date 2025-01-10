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

namespace RecipeGenerator.Tests.Database.Repositories.Steps
{
    public partial class StepsRepositoryTests
    {
        private readonly IMapper mapper;
        public StepsRepositoryTests()
        {
            mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();
        }

        private StepsRepository GetRepository(RecipeGeneratorDbContext context)
        {
            return new StepsRepository(new NullLogger<StepsRepository>(), context, mapper);
        }
    }
}
