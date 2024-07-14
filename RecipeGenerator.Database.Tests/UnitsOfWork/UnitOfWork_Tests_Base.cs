using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Newtonsoft.Json.Bson;
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
using System.Reflection;
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
            GetAllResponseItem,
            GetAllResponse,
            GetRequest,
            GetResponse,
            UpdateRequest,
            UpdateResponse
        >
        where Entity : class, IRecipeGeneratorEntity
        where CreateRequest : ICreateRequest
        where CreateResponse : ICreateResponse
        where DeleteRequest : IDeleteRequest
        where DeleteResponse : IDeleteResponse
        where GetAllRequest : IGetAllRequest
        where GetAllResponseItem : IGetAllResponseItem
        where GetAllResponse : IGetAllResponse<IGetAllResponseItem>
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

        protected abstract void EditRequest<EditRequest>(EditRequest req);

        protected abstract void CompareEntities<EditRequest, EditResponse>(EditRequest req, EditResponse res);

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

        [Fact]
        public async Task DeleteAsync_Normal()
        {
            //arrange
            Entity entity = (Entity)(await dbContext.AddAsync(Activator.CreateInstance<Entity>())).Entity;
            await dbContext.SaveChangesAsync();

            DeleteRequest req = Activator.CreateInstance<DeleteRequest>();
            req.Id = entity.Id;
            //act
            DeleteResponse? response = await unitOfWork.DeleteAsync<Entity, DeleteRequest, DeleteResponse>(req);
            await dbContext.SaveChangesAsync();
            //assert
            Assert.NotNull(response);
            Assert.Equal(req.Id, response.Id);

            var deletedEntity = await dbContext.FindAsync<Entity>(req.Id);
            Assert.Null(deletedEntity);
        }

        [Theory]
        [InlineData(0, 0, null, 5, 5)]
        [InlineData(0, 0, "Fitlered name", 5, 3)]
        [InlineData(0, 2, null, 5, 2)]
        [InlineData(1, 2, null, 5, 2)]
        public async Task GetAllAsync_Normal(int pageNumber, int pageSize, string fitler, int totalCount, int expectedCount)
        {
            //arrange
            for (int i = 0; i < totalCount; ++i)
            {
                Entity entity = (await dbContext.AddAsync(Activator.CreateInstance<Entity>())).Entity;
                if (i % 2 == 0 && !string.IsNullOrEmpty(fitler))
                {
                    PropertyInfo? propertyInfo = typeof(Entity).GetProperty("Name");
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(entity, fitler, null);
                    }
                    else
                    {

                    }
                }
            }
            await dbContext.SaveChangesAsync();
            GetAllRequest req = Activator.CreateInstance<GetAllRequest>();
            req.PageNumber = pageNumber;
            req.PageSize = pageSize;
            req.Filter = fitler;
            //act
            GetAllResponse? response = await unitOfWork.GetAllAsync<Entity, GetAllRequest, GetAllResponse, GetAllResponseItem>(req);
            await dbContext.SaveChangesAsync();
            //assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Items);
            Assert.Equal(expectedCount, response.Items.Count());
        }

        [Fact]
        public async Task GetAsync_Normal()
        {
            //arrange
            Entity entity = (await dbContext.AddAsync(Activator.CreateInstance<Entity>())).Entity;
            await dbContext.SaveChangesAsync();

            GetRequest req = Activator.CreateInstance<GetRequest>();
            req.Id = entity.Id;
            //act
            GetResponse? response = await unitOfWork.GetAsync<Entity, GetRequest, GetResponse>(req);
            await dbContext.SaveChangesAsync();
            //assert
            Assert.NotNull(response);
            Assert.Equal(req.Id, response.Id);
        }

        [Fact]
        public async Task UpdateAsync_Normal()
        {
            //arrange
            Entity entity = (await dbContext.AddAsync(Activator.CreateInstance<Entity>())).Entity;
            await dbContext.SaveChangesAsync();

            UpdateRequest req = Activator.CreateInstance<UpdateRequest>();
            req.Id = entity.Id;
            EditRequest(req);
            //act
            UpdateResponse? response = await unitOfWork.UpdateAsync<Entity, UpdateRequest, UpdateResponse>(req);
            await dbContext.SaveChangesAsync();
            //assert
            Assert.NotNull(response);
            CompareEntities(req, response);
        }

    }
}
