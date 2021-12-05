using BlazingGEL.WASM.Dtos;
using BlazingGEL.WASM.ServiceInterfaces;

namespace BlazingGEL.WASM.Services;

public class PostRepository : BaseRepository<PostDto>, IPostRepository
{
    private readonly HttpClient _httpClient;

    public PostRepository(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
