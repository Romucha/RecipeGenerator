using AutoMapper;
using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.ApplicableIngredients
{
    public partial class ApplicableIngredientsRepositoryTests
    {
        private readonly IMapper mapper;
        public ApplicableIngredientsRepositoryTests()
        {
            mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();
        }

        private ApplicableIngredientsRepository GetRepository(RecipeGeneratorDbContext context)
        {
            return new ApplicableIngredientsRepository(new NullLogger<ApplicableIngredientsRepository>(), context, mapper);
        }
    }
}
