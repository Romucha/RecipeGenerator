using AutoMapper;
using RecipeGenerator.DTO.AppliedIngredients;
using RecipeGenerator.DTO.Ingredients;
using RecipeGenerator.DTO.Recipes;
using RecipeGenerator.DTO.Steps;
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
            CreateMap<CreateApplicableIngredientDTO, ApplicableIngredient>().ReverseMap();
            CreateMap<GetApplicableIngredientDTO, ApplicableIngredient>().ReverseMap();
            CreateMap<DeleteApplicableIngredientDTO, ApplicableIngredient>().ReverseMap();
            CreateMap<UpdateApplicableIngredientDTO, ApplicableIngredient>().ReverseMap();

            CreateMap<CreateStepDTO, Step>().ReverseMap();
            CreateMap<GetStepDTO, Step>().ReverseMap();
            CreateMap<DeleteStepDTO, Step>().ReverseMap();
            CreateMap<UpdateStepDTO, Step>().ReverseMap();

            CreateMap<CreateRecipeDTO, Recipe>().ReverseMap();
            CreateMap<GetRecipeDTO, Recipe>().ReverseMap();
            CreateMap<DeleteRecipeDTO, Recipe>().ReverseMap();
            CreateMap<UpdateRecipeDTO, Recipe>().ReverseMap();

            CreateMap<CreateAppliedIngredientDTO, AppliedIngredient>().ReverseMap();
            CreateMap<DeleteAppliedIngredientDTO, AppliedIngredient>().ReverseMap();
            CreateMap<GetAppliedIngredientDTO, AppliedIngredient>().ReverseMap();
            CreateMap<UpdateAppliedIngredientDTO, AppliedIngredient>().ReverseMap();
        }
    }
}
