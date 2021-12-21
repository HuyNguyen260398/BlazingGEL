using BlazingGEL.WASM.Dtos;
using BlazingGEL.WASM.ServiceInterfaces;
using System.Net.Http.Json;

namespace BlazingGEL.WASM.Services;

public class CommentRepository : BaseRepository<CommentDto>, ICommentRepository
{
    private readonly HttpClient _httpClient;

    public CommentRepository(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CommentDto>> GetByPostAsync(string url, int postId)
    {
        try
        {
            if (postId < 1)
                return null;

            var response = await _httpClient.GetFromJsonAsync<IEnumerable<CommentDto>>(url + postId);
            return response;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
