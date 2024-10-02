using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.Logging;
using RecipeGenerator.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Services
{
    public class FileSaverService : IFileSaverService
    {
        private readonly ILogger<FileSaverService> _logger;

        public FileSaverService(ILogger<FileSaverService> logger)
        {
            this._logger = logger;
        }
        public async Task<string> SaveFileAsync(byte[] file, CancellationToken cancellationToken = default)
        {
            try
            {
                using var stream = new MemoryStream(file);
                var fileSaverResult = await FileSaver.Default.SaveAsync($"recipe-{DateTime.UtcNow:yyyy-MM-dd_hh-mm-ss}.pdf", stream, cancellationToken);
                if (fileSaverResult.IsSuccessful)
                {
                    await Toast.Make($"The file was saved successfully to location: {fileSaverResult.FilePath}").Show(cancellationToken);
                    return fileSaverResult.FilePath;
                }
                else
                {
                    await Toast.Make($"The file was not saved successfully with error: {fileSaverResult.Exception.Message}").Show(cancellationToken);
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(SaveFileAsync));
                throw;
            }
        }
    }
}
