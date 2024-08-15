namespace RecipeGenerator.DTO.Interfaces.Requests
{
    public interface IGetAllRequest
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }

        string Filter { get; set; }
    }
}
