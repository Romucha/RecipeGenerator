using AutoMapper;
using RecipeGenerator.DTO.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.AppliedIngredients;
using RecipeGenerator.DTO.AppliedIngredients.Requests;
using RecipeGenerator.DTO.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Recipes;
using RecipeGenerator.DTO.Recipes.Requests;
using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.DTO.Steps;
using RecipeGenerator.DTO.Steps.Requests;
using RecipeGenerator.DTO.Steps.Responses;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Mapping
{
    internal class MapperInitializer : Profile
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
            CreateMap<UpdateRecipeResponse, Recipe>().ReverseMap();
        }
    }
}
