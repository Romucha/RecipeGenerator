namespace RecipeGenerator.DTO.Interfaces.Responses
{
    public interface IGetAllResponse<T> where T : IGetAllResponseItem
    {
        IEnumerable<T> Items { get; set; }
    }
}
