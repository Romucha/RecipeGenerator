using AutoMapper;
using Moq;
using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.Mapping;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Tests.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace RecipeGenerator.API.Tests.Models.Ingredients
{
    public class IngredientFactory_Tests
    {
        private readonly IMapper mapper;
        private readonly IIngredientFactory ingredientFactory;
        public IngredientFactory_Tests()
        {
            var configuration = new MapperConfiguration(c => c.AddProfile(new MapperInitializer()));
            mapper = configuration.CreateMapper();
            ingredientFactory = new IngredientFactory(mapper);
        }

        [Fact]
        public void Create_Normal()
        {
            //arrange
            string name = "Name";
            string description = "Description";
            Uri link = new Uri("http://uri.uri");
            string image = "";
            IngredientType ingredientType = IngredientType.Fruits;
            //act
            var ingredient = ingredientFactory.Create(name, description, link, image, ingredientType);
            //assert
            Assert.NotNull(ingredient);
            Assert.Equal(name, ingredient.Name);
            Assert.Equal(description, ingredient.Description);
            Assert.Equal(link, ingredient.Link);
            Assert.Equal(image, ingredient.Image);
            Assert.Equal(ingredientType, ingredient.IngredientType);
        }

        [Fact]
        public void CreateFromDTO_Normal()
        {
            //arrange
            CreateIngredientDTO createIngredientDTO = mapper.Map<CreateIngredientDTO>(IngredientSamples.NormalIngredient);
            //act
            var ingredient = ingredientFactory.CreateFromDTO(createIngredientDTO);
            //assert
            Assert.NotNull(ingredient);
            Assert.Equal(createIngredientDTO.Name, ingredient.Name);
            Assert.Equal(createIngredientDTO.Description, ingredient.Description);
            Assert.Equal(createIngredientDTO.Link, ingredient.Link);
            Assert.Equal(createIngredientDTO.Image, ingredient.Image);
            Assert.Equal(createIngredientDTO.IngredientType, ingredient.IngredientType);
        }

        [Fact]
        public void CreateFromDTO_Empty()
        {
            //arrange
            CreateIngredientDTO createIngredientDTO = mapper.Map<CreateIngredientDTO>(IngredientSamples.EmptyIngredient);
            //act
            var ingredient = ingredientFactory.CreateFromDTO(createIngredientDTO);
            //assert
            Assert.NotNull(ingredient);
            Assert.Equal(createIngredientDTO.Name, ingredient.Name);
            Assert.Equal(createIngredientDTO.Description, ingredient.Description);
            Assert.Equal(createIngredientDTO.Link, ingredient.Link);
            Assert.Equal(createIngredientDTO.Image, ingredient.Image);
            Assert.Equal(createIngredientDTO.IngredientType, ingredient.IngredientType);
        }

        [Fact]
        public void CreateFromDTO_Null()
        {//arrange
            CreateIngredientDTO createIngredientDTO = mapper.Map<CreateIngredientDTO>(IngredientSamples.NullIngredient);
            //act
            var ingredient = ingredientFactory.CreateFromDTO(createIngredientDTO);
            //assert
            Assert.Null(ingredient);

        }
    }
}
