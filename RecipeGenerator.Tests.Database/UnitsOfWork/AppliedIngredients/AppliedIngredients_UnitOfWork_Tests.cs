using RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.UnitsOfWork.AppliedIngredients
{
    public class AppliedIngredients_UnitOfWork_Tests : UnitOfWork_Tests_Base
        <
            AppliedIngredient,
            CreateAppliedIngredientRequest,
            CreateAppliedIndredientResponse,
            DeleteAppliedIngredientRequest,
            DeleteAppliedIngredientResponse,
            GetAllAppliedIngredientsRequest,
            GetAllAppliedIngredientResponse,
            GetAllAppliedIngredientsResponse,
            GetAppliedIngredientRequest,
            GetAppliedIngredientResponse,
            UpdateAppliedIngredientRequest,
            UpdateAppliedIngredientResponse
        >
    {
        private Guid _recipeId;

        private Guid _ingredientId;

        public AppliedIngredients_UnitOfWork_Tests() : base()
        {
            var recipe = new Recipe();
            var ingredient = new ApplicableIngredient();

            dbContext.Add(recipe);
            dbContext.Add(ingredient);

            _recipeId = recipe.Id;
            _ingredientId = ingredient.Id;

            dbContext.SaveChanges();
        }

        protected override void CompareEntities<EditRequest, EditResponse>(EditRequest req, EditResponse res)
        {
            var request = req as UpdateAppliedIngredientRequest;
            var response = res as UpdateAppliedIngredientResponse;
            if (response is null || request is null)
            {
                throw new NullReferenceException();
            }
            Assert.Equal(request.Id, response.Id);
            Assert.Equal(request.RecipeId, response.RecipeId);
            Assert.Equal(request.IngredientId, response.IngredientId);
        }

        protected override void EditRequest<EditRequest>(EditRequest req)
        {
            var request = req as UpdateAppliedIngredientRequest;
            if (request is null)
                throw new NullReferenceException();
            request.IngredientId = _ingredientId;
            request.RecipeId = _recipeId;
        }
    }
}
