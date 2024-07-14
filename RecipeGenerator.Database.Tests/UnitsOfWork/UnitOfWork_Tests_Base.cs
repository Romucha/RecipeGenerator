using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.Interfaces.Requests;
using RecipeGenerator.DTO.Interfaces.Responses;
using RecipeGenerator.Models;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.UnitsOfWork
{
    public abstract class UnitOfWork_Tests_Base
        <
            Entity,
            CreateRequest,
            CreateResponse,
            DeleteRequest,
            DeleteResponse,
            GetAllRequest,
            GetAllResponse,
            GetAllResponseItem,
            GetRequest,
            GetResponse,
            UpdateRequest,
            UpdateResponse
        >
        where Entity : IRecipeGeneratorEntity
        where CreateRequest : ICreateRequest
        where CreateResponse : ICreateResponse
        where DeleteRequest : IDeleteRequest
        where DeleteResponse : IDeleteResponse
        where GetAllRequest : IGetAllRequest
        where GetAllResponse : IGetAllResponse<GetAllResponseItem>
        where GetAllResponseItem : IGetAllResponseItem
        where GetRequest : IGetRequest
        where GetResponse : IGetResponse
        where UpdateRequest : IUpdateRequest
        where UpdateResponse : IUpdateResponse
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly RecipeGeneratorDbContext dbContext;

        protected readonly IRepository<ApplicableIngredient> applicableIngredientRepository;
        protected readonly IRepository<AppliedIngredient> appliedIngredientRepository;
        protected readonly IRepository<Step> stepRepository;
        protected readonly IRepository<Recipe> recipeRepository;

        public UnitOfWork_Tests_Base()
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
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            CreateRequest request = Activator.CreateInstance<CreateRequest>();
            //act
            CreateResponse? response = await unitOfWork.CreateAsync<Entity, CreateRequest, CreateResponse>(request);
            //assert
            Assert.NotNull(response);
            Assert.NotEqual(default, response.Id);
        }

        //public abstract Task DeleteAsync_Normal();

        //public abstract Task UpdateAsync_Normal();

        //public abstract Task GetAsync_Normal();

        //public abstract Task GetAllAsync_Normal(int pageNumber, int pageSize, string fitler, int totalCount, int expectedCount);
    }
}
