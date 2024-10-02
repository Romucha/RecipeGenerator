using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Services
{
    public interface IFileSaverService
    {
        Task<string> SaveFileAsync(byte[] file, CancellationToken cancellationToken = default);
    }
}
