using AutoMapper;
using RecipeGenerator.API.DTO.AppliedIngredients;
using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.DTO.Steps;
using RecipeGenerator.API.Models.AppliedIngredients;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Mapping
{
    internal class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<CreateIngredientDTO, Ingredient>().ReverseMap();
            CreateMap<GetIngredientDTO, Ingredient>().ReverseMap();
            CreateMap<DeleteIngredientDTO, Ingredient>().ReverseMap();
            CreateMap<UpdateIngredientDTO, Ingredient>().ReverseMap();

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
