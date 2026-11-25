namespace Library.API.Dtos.CategoryDtos;

public class CreateCategoryRequest
{
    public string CatName { get; set; } = null!;
}

public class UpdateCategoryRequest
{
    public string CatName { get; set; } = null!;
}

public class GetCategoryResponse
{
    public int Id { get; set; }
    public string CatName { get; set; } = null!;
}
