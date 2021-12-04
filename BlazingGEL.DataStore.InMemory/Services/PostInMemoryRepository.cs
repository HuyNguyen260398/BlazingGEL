using BlazingGEL.API.DataStoreInterfaces;
using BlazingGEL.CoreBusiness.Models;

namespace BlazingGEL.DataStore.InMemory.Services;

public class PostInMemoryRepository : IPostRepository
{
    private List<Post> posts;

    public PostInMemoryRepository()
    {
        // Init in-memory list
        posts = new()
        {
            new Post
            {
                PostId = 1,
                Title = "Post 1",
                Description = "Desc 1",
                CategoryId = 1,
                SubCategoryId = 1,
                Slug = "Slug 1",
                Thumbnail = "",
                Content = "Content 1",
                CreatedAt = DateTime.Now,
                PublishedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Views = 1,
                Comments = 1
            },
            new Post
            {
                PostId = 2,
                Title = "Post 2",
                Description = "Desc 2",
                CategoryId = 2,
                SubCategoryId = 2,
                Slug = "Slug 2",
                Thumbnail = "",
                Content = "Content 2",
                CreatedAt = DateTime.Now,
                PublishedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Views = 2,
                Comments = 2
            },
            new Post
            {
                PostId = 3,
                Title = "Post 3",
                Description = "Desc 3",
                CategoryId = 3,
                SubCategoryId = 3,
                Slug = "Slug 3",
                Thumbnail = "",
                Content = "Content 3",
                CreatedAt = DateTime.Now,
                PublishedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Views = 3,
                Comments = 3
            }
        };
    }

    public async Task<bool> CreatePost(Post post)
    {
        if (posts.Any(p => p.Title.Equals(post.Title, StringComparison.OrdinalIgnoreCase)))
            return await Task.FromResult(false);

        if (posts != null && posts.Count > 0)
            post.PostId = posts.Max(p => p.PostId) + 1;
        else
            post.PostId = 1;

        posts.Add(post);
        return await Task.FromResult(true);
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        return await Task.FromResult(posts);
    }

    public async Task<Post> GetPost(int id)
    {
        var post = posts.FirstOrDefault(p => p.PostId == id);
        return await Task.FromResult(post);
    }

    public async Task<bool> UpdatePost(Post post)
    {
        var postToUpdate = posts.FirstOrDefault(p => p.PostId == post.PostId);
        if (postToUpdate == null)
            return await Task.FromResult(false);

        //postToUpdate.Title = post.Title;
        //postToUpdate.Description = post.Description;
        //postToUpdate.CategoryId = post.CategoryId;
        //postToUpdate.SubCategoryId = post.SubCategoryId;
        //postToUpdate.Slug = post.Slug;
        //postToUpdate.Thumbnail = post.Thumbnail;
        //postToUpdate.Content = post.Content;
        //postToUpdate.UpdatedAt = DateTime.Now;

        postToUpdate = post;
        return await Task.FromResult(true); 
    }

    public async Task<bool> DeletePost(int id)
    {
        var postToDelete = posts.FirstOrDefault(p => p.PostId == id);
        if (postToDelete == null)
            return await Task.FromResult(false);

        posts.Remove(postToDelete);
        return await Task.FromResult(true);
    }
}
