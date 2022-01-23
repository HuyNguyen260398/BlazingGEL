using BlazingGEL.CoreBusiness.Dtos;
using BlazingGEL.WASM.ServiceInterfaces;

namespace BlazingGEL.WASM.Services;

public class CategoryRepository : BaseRepository<CategoryDto>, ICategoryRepository
{
    private readonly HttpClient _httpClient;

    public CategoryRepository(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
