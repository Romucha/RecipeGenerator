using AutoMapper;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Implementations.Recipes.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
using RecipeGenerator.Models.Ingredients;
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
        }

        private void mapApplicableIngredients()
        {
            CreateMap<CreateApplicableIngredientRequest, ApplicableIngredient>().ReverseMap();
            CreateMap<DeleteApplicableIngredientRequest, ApplicableIngredient>().ReverseMap();
            CreateMap<GetApplicableIngredientRequest, ApplicableIngredient>().ReverseMap();
            CreateMap<UpdateApplicableIngredientRequest, ApplicableIngredient>().ReverseMap();

            CreateMap<CreateApplicableIndredientResponse, ApplicableIngredient>().ReverseMap();
            CreateMap<DeleteApplicableIngredientResponse, ApplicableIngredient>().ReverseMap();
            CreateMap<GetAllApplicableIngredientResponse, ApplicableIngredient>().ReverseMap();
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
            CreateMap<GetAllAppliedIngredientResponse, AppliedIngredient>().ReverseMap();
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
            CreateMap<GetAllStepResponse, Step>().ReverseMap();
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
            CreateMap<GetAllRecipeResponse, Recipe>().ReverseMap();
            CreateMap<GetRecipeResponse, Recipe>().ReverseMap();
            CreateMap<UpdateRecipeResponse, Recipe>().ReverseMap();
        }
    }
}
