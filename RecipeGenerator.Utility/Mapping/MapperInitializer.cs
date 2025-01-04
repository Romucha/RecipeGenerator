using AutoMapper;
using RecipeGenerator.DTO.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.AppliedIngredients.Requests;
using RecipeGenerator.DTO.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Measurements.Requests;
using RecipeGenerator.DTO.Measurements.Responses;
using RecipeGenerator.DTO.Recipes.Requests;
using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.DTO.Steps.Requests;
using RecipeGenerator.DTO.Steps.Responses;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;

namespace RecipeGenerator.Utility.Mapping
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            mapApplicableIngredients();
            mapAppliedIngredients();
            mapSteps();
            mapRecipes();
            mapMeasurements();
        }

        private void mapApplicableIngredients()
        {
            CreateMap<CreateApplicableIngredientRequest, ApplicableIngredient>().ReverseMap();
            CreateMap<DeleteApplicableIngredientRequest, ApplicableIngredient>().ReverseMap();
            CreateMap<GetApplicableIngredientRequest, ApplicableIngredient>().ReverseMap();
            CreateMap<UpdateApplicableIngredientRequest, ApplicableIngredient>().ReverseMap();

            CreateMap<CreateApplicableIndredientResponse, ApplicableIngredient>().ReverseMap();
            CreateMap<DeleteApplicableIngredientResponse, ApplicableIngredient>().ReverseMap();
            CreateMap<GetAllApplicableIngredientsResponseItem, ApplicableIngredient>().ReverseMap();
            CreateMap<GetApplicableIngredientResponse, ApplicableIngredient>().ReverseMap();
            CreateMap<UpdateApplicableIngredientResponse, ApplicableIngredient>().ReverseMap();
        }

        private void mapAppliedIngredients()
        {
            CreateMap<CreateAppliedIngredientRequest, AppliedIngredient>().ReverseMap();
            CreateMap<DeleteAppliedIngredientRequest, AppliedIngredient>().ReverseMap();
            CreateMap<GetAppliedIngredientRequest, AppliedIngredient>().ReverseMap();
            CreateMap<UpdateAppliedIngredientRequest, AppliedIngredient>().ReverseMap();

            CreateMap<CreateAppliedIndredientResponse, AppliedIngredient>().ReverseMap();
            CreateMap<DeleteAppliedIngredientResponse, AppliedIngredient>().ReverseMap();
            CreateMap<GetAllAppliedIngredientsResponseItem, AppliedIngredient>().ReverseMap();
            CreateMap<GetAppliedIngredientResponse, AppliedIngredient>().ReverseMap();
            CreateMap<UpdateAppliedIngredientResponse, AppliedIngredient>().ReverseMap();
        }

        private void mapSteps()
        {
            CreateMap<CreateStepRequest, Step>().ReverseMap();
            CreateMap<DeleteStepRequest, Step>().ReverseMap();
            CreateMap<GetStepRequest, Step>().ReverseMap();
            CreateMap<UpdateStepRequest, Step>().ReverseMap();

            CreateMap<CreateStepResponse, Step>().ReverseMap();
            CreateMap<DeleteStepResponse, Step>().ReverseMap();
            CreateMap<GetAllStepsResponseItem, Step>().ReverseMap();
            CreateMap<GetStepResponse, Step>().ReverseMap();
            CreateMap<UpdateStepResponse, Step>().ReverseMap();
        }

        private void mapRecipes()
        {
            CreateMap<CreateRecipeRequest, Recipe>().ReverseMap();
            CreateMap<DeleteRecipeRequest, Recipe>().ReverseMap();
            CreateMap<GetRecipeRequest, Recipe>().ReverseMap();
            CreateMap<UpdateRecipeRequest, Recipe>().ReverseMap();

            CreateMap<CreateRecipeResponse, Recipe>().ReverseMap();
            CreateMap<DeleteRecipeResponse, Recipe>().ReverseMap();
            CreateMap<GetAllRecipesResponseItem, Recipe>().ReverseMap();
            CreateMap<GetRecipeResponse, Recipe>().ReverseMap();
            CreateMap<UpdateRecipeResponse, Recipe>().ReverseMap();
        }

        private void mapMeasurements()
        {
            CreateMap<CreateMeasurmentRequest, Measurement>().ReverseMap();
            CreateMap<DeleteMeasurementRequest, Measurement>().ReverseMap();
            CreateMap<GetMeasurementRequest, Measurement>().ReverseMap();
            CreateMap<UpdateMeasurementRequest, Measurement>().ReverseMap();

            CreateMap<CreateMeasurementResponse, Measurement>().ReverseMap();
            CreateMap<DeleteMeasurementResponse, Measurement>().ReverseMap();
            CreateMap<GetAllMeasurementsResponseItem, Measurement>().ReverseMap();
            CreateMap<GetMeasurementResponse, Measurement>().ReverseMap();
            CreateMap<UpdateMeasurementResponse, Measurement>().ReverseMap();
        }
    }
}
