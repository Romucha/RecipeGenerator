using RecipeGenerator.DTO.ApplicableIngredients.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.UnitsOfWork.ApplicableIngredients
{
    public class ApplicableIngredients_UnitOfWork_Tests : UnitOfWork_Tests_Base
    {
        [Fact]
        public override async Task CreateAsync_Normal()
        {
            //arrange
            CreateApplicableIngredientRequest request = new();
            //act
            var response = await unitOfWork.CreateApplicableIndredientAsync(request);
            await unitOfWork.SaveChangesAsync();
            //assert
            Assert.NotNull(response);
            Assert.Equal(string.Empty, response.Name);
            Assert.Equal(string.Empty, response.Description);
            Assert.Equal(string.Empty, response.Image);
            Assert.Equal(0, response.IngredientType);
            Assert.Null(response.Link);
        }

        [Fact]
        public override async Task DeleteAsync_Normal()
        {
            //arrange
            var entity = await applicableIngredientRepository.CreateAsync();
            await unitOfWork.SaveChangesAsync();

            DeleteApplicableIngredientRequest req = new()
            {
                Id = entity!.Id
            };
            //act
            var response = await unitOfWork.DeleteApplicableIngredientAsync(req);
            await unitOfWork.SaveChangesAsync();
            //assert
            Assert.NotNull(response);
            Assert.Equal(req.Id, response.Id);
            Assert.Equal(entity.Name, response.Name);

            var deletedEntity = await applicableIngredientRepository.GetAsync(req.Id);
            Assert.Null(deletedEntity);
        }

        [Theory]
        [InlineData(0, 0, null, 5, 5)]
        [InlineData(0, 0, "Fitlered name", 5, 3)]
        //TO-DO: refactor pagination.
        [InlineData(0, 2, null, 5, 2)]
        public override async Task GetAllAsync_Normal(int pageNumber, int pageSize, string fitler, int totalCount, int expectedCount)
        {
            //arrange
            for (int i = 0; i < totalCount; ++i)
            {
                var entity = await applicableIngredientRepository.CreateAsync();
                if (i % 2 == 0 && !string.IsNullOrEmpty(fitler))
                {
                    entity!.Name = fitler;
                }
            }
            await unitOfWork.SaveChangesAsync();
            GetAllApplicableIngredientsRequest req = new()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Filter = fitler,
            };
            //act
            var response = await unitOfWork.GetAllApplicableIngredientAsync(req);
            await unitOfWork.SaveChangesAsync();
            //assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Items);
            Assert.Equal(expectedCount, response.Items.Count());

        }

        public override Task GetAsync_Normal()
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync_Normal()
        {
            throw new NotImplementedException();
        }
    }
}
