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
using RecipeGenerator.ViewModels.CreateOrEdit.Recipes;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;

namespace RecipeGenerator.ViewModels.Tests.Recipes
{
    public class CreateRecipeViewModel_Tests
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly RecipeGeneratorDbContext dbContext;

        protected readonly IRepository<ApplicableIngredient> applicableIngredientRepository;
        protected readonly IRepository<AppliedIngredient> appliedIngredientRepository;
        protected readonly IRepository<Step> stepRepository;
        protected readonly IRepository<Recipe> recipeRepository;

        protected readonly CreateOrEditRecipeViewModel createRecipeViewModel;

        public CreateRecipeViewModel_Tests()
        {
            ILogger<UnitOfWork> uowLogger = new NullLogger<UnitOfWork>();
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<RecipeGeneratorDbContext> dbContextOptions = new DbContextOptionsBuilder<RecipeGeneratorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            ApplicableIngredientsSeeder seeder = new ApplicableIngredientsSeeder(new NullLogger<ApplicableIngredientsSeeder>());

            dbContext = new RecipeGeneratorDbContext(seeder, configuration, dbContextOptions);

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

            createRecipeViewModel = new CreateOrEditRecipeViewModel(new NullLogger<CreateOrEditRecipeViewModel>(), unitOfWork);
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            createRecipeViewModel.RecipeName = "Test";
            createRecipeViewModel.RecipeDescription = "Test";
            createRecipeViewModel.RecipeCourseType = Course.Horsdoeuvres;
            createRecipeViewModel.RecipeEstimatedTime = 10;
            createRecipeViewModel.RecipeImage = [];
            createRecipeViewModel.RecipePortions = 10;
            //act
            await createRecipeViewModel.CreateAsync();
            await createRecipeViewModel.SaveAsync();
            //assert
            var recipe = await dbContext.Recipes.FirstOrDefaultAsync(c => c.Name == createRecipeViewModel.RecipeName);
            Assert.NotNull(recipe);
            Assert.Equal(createRecipeViewModel.RecipeName, recipe.Name);
            Assert.Equal(createRecipeViewModel.RecipeDescription, recipe.Description);
            Assert.Equal(createRecipeViewModel.RecipeCourseType, recipe.CourseType);
            Assert.Equal(createRecipeViewModel.RecipeImage, recipe.Image);
            Assert.Equal(createRecipeViewModel.RecipeEstimatedTime, recipe.EstimatedTime.TotalMinutes);
            Assert.Equal(createRecipeViewModel.RecipePortions, recipe.Portions);
        }
    }
}
