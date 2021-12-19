using BlazingGEL.WASM.Dtos;
using BlazingGEL.WASM.ServiceInterfaces;

namespace BlazingGEL.WASM.Services;

public class TagRepository : BaseRepository<TagDto>, ITagRepository
{
    private readonly HttpClient _httpClient;

    public TagRepository(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
