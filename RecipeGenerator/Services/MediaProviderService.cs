using Microsoft.Extensions.Logging;
using RecipeGenerator.ViewModels.Services;

namespace RecipeGenerator.Services
{
    /// <summary>
    /// Provides methods for taking and selecting photos.
    /// </summary>
    public class MediaProviderService : IMediaProviderService
    {
        private readonly ILogger<MediaProviderService> logger;

        public MediaProviderService(ILogger<MediaProviderService> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<byte[]> SelectPhotoAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Selecting a photo from file system...");
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult? photo = await MediaPicker.Default.PickPhotoAsync();

                    if (photo != null)
                    {
                        // save the file into local storage
                        string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                        using Stream sourceStream = await photo.OpenReadAsync();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            sourceStream.CopyTo(ms);
                            return ms.ToArray();
                        }
                    }
                }

                return Enumerable.Empty<byte>().ToArray();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SelectPhotoAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        /// <inheritdoc/>
        public async Task<byte[]> TakePhotoAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Taking a photo...");
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        // save the file into local storage
                        string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                        using Stream sourceStream = await photo.OpenReadAsync();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            sourceStream.CopyTo(ms);
                            return ms.ToArray();
                        }
                    }
                }

                return Enumerable.Empty<byte>().ToArray();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(TakePhotoAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
