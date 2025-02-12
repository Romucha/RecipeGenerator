using RecipeGenerator.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.ViewModels.Details.Recipes
{
    internal class DummyFileSaverService : IFileSaverService
    {
        public async Task<string> SaveFileAsync(byte[] file, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(string.Empty);
        }
    }
}
