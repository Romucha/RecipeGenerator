using Microsoft.EntityFrameworkCore;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Steps;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.Models.Recipes;

namespace RecipeGenerator.Database.Tests.UnitsOfWork.Steps
{
    public class Steps_UnitOfWork_Tests : UnitOfWork_Tests_Base
        <
            Step,
            CreateStepRequest,
            CreateStepResponse,
            DeleteStepRequest,
            DeleteStepResponse,
            GetAllStepsRequest,
            GetAllStepResponse,
            GetAllStepsResponse,
            GetStepRequest,
            GetStepResponse,
            UpdateStepRequest,
            UpdateStepResponse
        >
    {
        private Guid _recipeId;

        public Steps_UnitOfWork_Tests() : base()
        {
            var recipe = dbContext.Add(new Recipe()).Entity;

            _recipeId = recipe.Id;

            dbContext.SaveChanges();
        }

        protected override void CompareEntities<EditRequest, EditResponse>(EditRequest req, EditResponse res)
        {
            var request = req as UpdateStepRequest;
            var response = res as UpdateStepResponse;
            if (response is null || request is null)
            {
                throw new NullReferenceException();
            }
            Assert.Equal(request.Id, response.Id);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Description, response.Description);
            Assert.Equal(request.Photos, response.Photos);
            Assert.Equal(request.Index, response.Index);
            Assert.Equal(request.RecipeId, response.RecipeId);
        }

        protected override void EditRequest<EditRequest>(EditRequest req)
        {
            var request = req as UpdateStepRequest;
            if (request is null)
                throw new NullReferenceException();
            request.Name = nameof(EditRequest);
            request.Description = nameof(EditRequest);
            request.Index = 1;
            request.Photos = new();
            request.RecipeId = _recipeId;
        }
    }
}
