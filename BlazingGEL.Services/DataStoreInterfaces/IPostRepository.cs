using BlazingGEL.CoreBusiness.Models;

namespace BlazingGEL.API.Services;

public interface IPostRepository
{
    Task<bool> CreatePost(Post post);
    Task<IEnumerable<Post>> GetAllPosts();
    Task<Post> GetPostById(int id);
    Task<bool> UpdatePost(Post post);
    Task<bool> DeletePost(int id);
}
