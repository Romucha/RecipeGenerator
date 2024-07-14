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
            GetAllApplicableIngredientResponse,
            GetAllApplicableIngredientsResponse,
            GetApplicableIngredientRequest,
            GetApplicableIngredientResponse,
            UpdateApplicableIngredientRequest,
            UpdateApplicableIngredientResponse
        >
    {
        protected override void CompareEntities<EditRequest, EditResponse>(EditRequest req, EditResponse res)
        {
            var request = req as UpdateApplicableIngredientRequest;
            var response = res as UpdateApplicableIngredientResponse;
            if (response is null || request is null)
            {
                throw new NullReferenceException();
            }
            Assert.Equal(request.Id, response.Id);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Description, response.Description);
            Assert.Equal(request.IngredientType, response.IngredientType);
            Assert.Equal(request.Link, response.Link);
        }

        protected override void EditRequest<EditRequest>(EditRequest req)
        {
            var request = req as UpdateApplicableIngredientRequest;
            if (request is null)
                throw new NullReferenceException();
            request.Name = nameof(EditRequest);
            request.Description = nameof(EditRequest);
            request.Image = "12345";
            request.IngredientType = 2;
            request.Link = null;
        }
    }
}
