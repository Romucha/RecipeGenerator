using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RecipeGenerator.Utility.Mapping;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecipeGenerator.ViewModels.Recipes;

namespace RecipeGenerator.ViewModels.Tests.Recipes
{
    public class CreateRecipeViewModelTests
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly RecipeGeneratorDbContext dbContext;

        protected readonly IRepository<ApplicableIngredient> applicableIngredientRepository;
        protected readonly IRepository<AppliedIngredient> appliedIngredientRepository;
        protected readonly IRepository<Step> stepRepository;
        protected readonly IRepository<Recipe> recipeRepository;

        protected readonly CreateRecipeViewModel createRecipeViewModel;

        public CreateRecipeViewModelTests()
        {
            ILogger<UnitOfWork> uowLogger = new NullLogger<UnitOfWork>();
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<RecipeGeneratorDbContext> dbContextOptions = new DbContextOptionsBuilder<RecipeGeneratorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            dbContext = new RecipeGeneratorDbContext(configuration, dbContextOptions);

            ILogger<Repository<ApplicableIngredient>> raiLogger = new NullLogger<Repository<ApplicableIngredient>>();
            applicableIngredientRepository = new Repository<ApplicableIngredient>(dbContext, raiLogger);

            ILogger<Repository<AppliedIngredient>> raidLogger = new NullLogger<Repository<AppliedIngredient>>();
            appliedIngredientRepository = new Repository<AppliedIngredient>(dbContext, raidLogger);

            ILogger<Repository<Step>> stepLogger = new NullLogger<Repository<Step>>();
            stepRepository = new Repository<Step>(dbContext, stepLogger);

            ILogger<Repository<Recipe>> recipeLogger = new NullLogger<Repository<Recipe>>();
            recipeRepository = new Repository<Recipe>(dbContext, recipeLogger);

            var config = new MapperConfiguration(c => c.AddProfile(new MapperInitializer()));
            IMapper mapper = config.CreateMapper();

            unitOfWork = new UnitOfWork(
                uowLogger,
                dbContext,
                recipeRepository,
                stepRepository,
                appliedIngredientRepository,
                applicableIngredientRepository,
                mapper);

            createRecipeViewModel = new CreateRecipeViewModel(new NullLogger<CreateRecipeViewModel>(), unitOfWork);
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            createRecipeViewModel.RecipeName = "Test";
            createRecipeViewModel.RecipeDescription = "Test";
            createRecipeViewModel.RecipeCourseType = Course.Horsdoeuvres;
            createRecipeViewModel.RecipeEstimatedTime = TimeSpan.FromHours(10);
            createRecipeViewModel.RecipeImage = "Test";
            createRecipeViewModel.RecipePortions = 10;
            //act
            var id = await createRecipeViewModel.CreateAsync();
            //assert
            Assert.NotNull(id);
            var recipe = await dbContext.FindAsync<Recipe>(id);
            Assert.NotNull(recipe);
            Assert.Equal(createRecipeViewModel.RecipeName, recipe.Name);
            Assert.Equal(createRecipeViewModel.RecipeDescription, recipe.Description);
            Assert.Equal(createRecipeViewModel.RecipeCourseType, recipe.CourseType);
            Assert.Equal(createRecipeViewModel.RecipeImage, recipe.Image);
            Assert.Equal(createRecipeViewModel.RecipeEstimatedTime, recipe.EstimatedTime);
            Assert.Equal(createRecipeViewModel.RecipePortions, recipe.Portions);
        }
    }
}
