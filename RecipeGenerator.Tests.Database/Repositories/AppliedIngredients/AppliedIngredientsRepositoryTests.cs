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

namespace RecipeGenerator.Tests.Database.Repositories.AppliedIngredients
{
    public partial class AppliedIngredientsRepositoryTests
    {
        private readonly IMapper mapper;
        public AppliedIngredientsRepositoryTests()
        {
            mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();
        }

        private AppliedIngredientsRepository GetRepository(RecipeGeneratorDbContext context)
        {
            return new AppliedIngredientsRepository(new NullLogger<AppliedIngredientsRepository>(), context, mapper);
        }
    }
}
