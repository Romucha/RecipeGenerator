using RecipeGenerator.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.ViewModels.CreateOrEdit.Recipes
{
    public class DummyRecipeMediaProviderService : IMediaProviderService
    {
        public async Task<byte[]> SelectPhotoAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(RecipeGenerator.Tests.Data.Properties.Resources.RecipeNormal);
        }

        public async Task<byte[]> TakePhotoAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(RecipeGenerator.Tests.Data.Properties.Resources.RecipeNormal);
        }
    }
}
