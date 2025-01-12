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

namespace RecipeGenerator.Tests.Database.Repositories.Recipes
{
    public partial class RecipesRepositoryTests
    {
        private readonly IMapper mapper;
        public RecipesRepositoryTests()
        {
            mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();
        }

        private RecipesRepository GetRepository(RecipeGeneratorDbContext context)
        {
            return new RecipesRepository(new NullLogger<RecipesRepository>(), context, mapper);
        }
    }
}
