using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Responses;
using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.UnitsOfWork.ApplicableIngredients
{
    public class ApplicableIngredients_UnitOfWork_Tests : UnitOfWork_Tests_Base
        <
            ApplicableIngredient,
            CreateApplicableIngredientRequest,
            CreateApplicableIndredientResponse,
            DeleteApplicableIngredientRequest,
            DeleteApplicableIngredientResponse,
            GetAllApplicableIngredientsRequest,
            GetAllApplicableIngredientsResponse,
            GetAllApplicableIngredientResponse,
            GetApplicableIngredientRequest,
            GetApplicableIngredientResponse,
            UpdateApplicableIngredientRequest,
            UpdateApplicableIngredientResponse
        >
    {
        //[Fact]
        //public override async Task CreateAsync_Normal()
        //{
        //    //arrange
        //    CreateApplicableIngredientRequest request = new();
        //    //act
        //    var response = await unitOfWork.CreateApplicableIndredientAsync(request);
        //    await dbContext.SaveChangesAsync();
        //    //assert
        //    Assert.NotNull(response);
        //    Assert.Equal(string.Empty, response.Name);
        //    Assert.Equal(string.Empty, response.Description);
        //    Assert.Equal(string.Empty, response.Image);
        //    Assert.Equal(0, response.IngredientType);
        //    Assert.Null(response.Link);
        //}

        //[Fact]
        //public override async Task DeleteAsync_Normal()
        //{
        //    //arrange
        //    var entity = (await dbContext.AddAsync(new ApplicableIngredient())).Entity;
        //    await dbContext.SaveChangesAsync();

        //    DeleteApplicableIngredientRequest req = new()
        //    {
        //        Id = entity!.Id
        //    };
        //    //act
        //    var response = await unitOfWork.DeleteApplicableIngredientAsync(req);
        //    await dbContext.SaveChangesAsync();
        //    //assert
        //    Assert.NotNull(response);
        //    Assert.Equal(req.Id, response.Id);
        //    Assert.Equal(entity.Name, response.Name);

        //    var deletedEntity = await dbContext.FindAsync<ApplicableIngredient>(req.Id);
        //    Assert.Null(deletedEntity);
        //}

        //[Theory]
        //[InlineData(0, 0, null, 5, 5)]
        //[InlineData(0, 0, "Fitlered name", 5, 3)]
        ////TO-DO: refactor pagination.
        //[InlineData(0, 2, null, 5, 2)]
        //public override async Task GetAllAsync_Normal(int pageNumber, int pageSize, string fitler, int totalCount, int expectedCount)
        //{
        //    //arrange
        //    for (int i = 0; i < totalCount; ++i)
        //    {
        //        var entity = await dbContext.AddAsync(new ApplicableIngredient());
        //        if (i % 2 == 0 && !string.IsNullOrEmpty(fitler))
        //        {
        //            entity.Entity!.Name = fitler;
        //        }
        //    }
        //    await dbContext.SaveChangesAsync();
        //    GetAllApplicableIngredientsRequest req = new()
        //    {
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        Filter = fitler,
        //    };
        //    //act
        //    var response = await unitOfWork.GetAllApplicableIngredientAsync(req);
        //    await dbContext.SaveChangesAsync();
        //    //assert
        //    Assert.NotNull(response);
        //    Assert.NotEmpty(response.Items);
        //    Assert.Equal(expectedCount, response.Items.Count());

        //}

        //[Fact]
        //public override async Task GetAsync_Normal()
        //{
        //    //arrange
        //    var entity = (await dbContext.AddAsync(new ApplicableIngredient())).Entity;
        //    await dbContext.SaveChangesAsync();

        //    GetApplicableIngredientRequest req = new()
        //    {
        //        Id = entity!.Id
        //    };
        //    //act
        //    var response = await unitOfWork.GetApplicableIngredientAsync(req);
        //    await dbContext.SaveChangesAsync();
        //    //assert
        //    Assert.NotNull(response);
        //    Assert.Equal(req.Id, response.Id);
        //    Assert.Equal(entity.Name, response.Name);
        //    Assert.Equal(entity.Description, response.Description);
        //    Assert.Equal(entity.Image, response.Image);
        //    Assert.Equal((int)entity.IngredientType, response.IngredientType);
        //    Assert.Equal(entity.Link, response.Link);
        //}

        //[Fact]
        //public override async Task UpdateAsync_Normal()
        //{
        //    //arrange
        //    var entity = (await dbContext.AddAsync(new ApplicableIngredient())).Entity;
        //    await dbContext.SaveChangesAsync();

        //    UpdateApplicableIngredientRequest req = new()
        //    {
        //        Id = entity!.Id,
        //        Name = nameof(UpdateAsync_Normal),
        //        Description = nameof(UpdateAsync_Normal),
        //        IngredientType = 2,
        //        Image = null,
        //        Link = null
        //    };
        //    //act
        //    var response = await unitOfWork.UpdateApplicableIngredientAsync(req);
        //    await dbContext.SaveChangesAsync();
        //    //assert
        //    Assert.NotNull(response);
        //    Assert.Equal(req.Id, response.Id);
        //    Assert.Equal(entity.Name, response.Name);
        //    Assert.Equal(entity.Description, response.Description);
        //    Assert.Equal(entity.Image, response.Image);
        //    Assert.Equal((int)entity.IngredientType, response.IngredientType);
        //    Assert.Equal(entity.Link, response.Link);
        //}
    }
}
