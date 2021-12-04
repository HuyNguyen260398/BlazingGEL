using BlazingGEL.CoreBusiness.Models;

namespace BlazingGEL.API.DataStoreInterfaces;

public interface IPostRepository
{
    Task<bool> CreatePost(Post post);
    Task<IEnumerable<Post>> GetPosts();
    Task<Post> GetPost(int id);
    Task<bool> UpdatePost(Post post);
    Task<bool> DeletePost(int id);
}
