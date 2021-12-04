using BlazingGEL.API.Services;
using BlazingGEL.Services.ServiceInterface;

namespace BlazingGEL.Services.PostServices;

public class GetPosts : IGetPosts
{
    private readonly IPostRepository _postRepo;

    public GetPosts(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task Execute()
    {
        await _postRepo.GetPosts();
    }
}
