using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.UnitsOfWork
{
    public class UnitOfWorkTests
    {
        [Fact]
        public async Task Constructor_Normal()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(
                    new NullLogger<UnitOfWork>(),
                    context,
                    new RecipesRepository(new NullLogger<RecipesRepository>(), context, mapper),
                    new StepsRepository(new NullLogger<StepsRepository>(), context, mapper),
                    new AppliedIngredientsRepository(new NullLogger<AppliedIngredientsRepository>(), context, mapper),
                    new ApplicableIngredientsRepository(new NullLogger<ApplicableIngredientsRepository>(), context, mapper),
                    new MeasurementsRepository(new NullLogger<MeasurementsRepository>(), context, mapper),
                    mapper))
                {
                    Assert.NotNull(unitOfWork);
                    Assert.NotNull(unitOfWork.ApplicableIngredientRepository);
                    Assert.NotNull(unitOfWork.AppliedIngredientRepository);
                    Assert.NotNull(unitOfWork.MeasurementsRepository);
                    Assert.NotNull(unitOfWork.RecipeRepository);
                    Assert.NotNull(unitOfWork.StepRepository);
                }
            }  
        }

        [Fact]
        public async Task SaveChanges_Normal()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(
                    new NullLogger<UnitOfWork>(),
                    context,
                    new RecipesRepository(new NullLogger<RecipesRepository>(), context, mapper),
                    new StepsRepository(new NullLogger<StepsRepository>(), context, mapper),
                    new AppliedIngredientsRepository(new NullLogger<AppliedIngredientsRepository>(), context, mapper),
                    new ApplicableIngredientsRepository(new NullLogger<ApplicableIngredientsRepository>(), context, mapper),
                    new MeasurementsRepository(new NullLogger<MeasurementsRepository>(), context, mapper),
                    mapper))
                {
                    var response = await unitOfWork.RecipeRepository.CreateAsync();
                    await unitOfWork.SaveChangesAsync();

                    Assert.NotNull(response);
                }
            }
        }

        [Fact]
        public async Task SaveChanges_Normal_NoActionTaken()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(
                    new NullLogger<UnitOfWork>(),
                    context,
                    new RecipesRepository(new NullLogger<RecipesRepository>(), context, mapper),
                    new StepsRepository(new NullLogger<StepsRepository>(), context, mapper),
                    new AppliedIngredientsRepository(new NullLogger<AppliedIngredientsRepository>(), context, mapper),
                    new ApplicableIngredientsRepository(new NullLogger<ApplicableIngredientsRepository>(), context, mapper),
                    new MeasurementsRepository(new NullLogger<MeasurementsRepository>(), context, mapper),
                    mapper))
                {
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }
    }
}
