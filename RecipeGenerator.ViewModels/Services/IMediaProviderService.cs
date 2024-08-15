namespace RecipeGenerator.ViewModels.Services
{
    /// <summary>
    /// Provides methods for taking and selecting images.
    /// </summary>
    public interface IMediaProviderService
    {
        /// <summary>
        /// Takes a photo.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<byte[]> TakePhotoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Select a photo from file system.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<byte[]> SelectPhotoAsync(CancellationToken cancellationToken = default);
    }
}
