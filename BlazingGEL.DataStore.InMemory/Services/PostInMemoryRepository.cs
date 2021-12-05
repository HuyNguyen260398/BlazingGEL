using BlazingGEL.CoreBusiness.Models;
using BlazingGEL.Services.DataStoreInterfaces;

namespace BlazingGEL.DataStore.InMemory.Services;

public class PostInMemoryRepository : IPostRepository
{
    private static List<Post> _posts = new()
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

    public async Task<bool> IsExistsAsync(int id)
    {
        return await Task.FromResult(_posts.Any(p => p.PostId == id));
    }

    public async Task<bool> CreateAsync(Post post)
    {
        if (_posts.Any(p => p.Title.Equals(post.Title, StringComparison.OrdinalIgnoreCase)))
            return await Task.FromResult(false);

        if (_posts != null && _posts.Count > 0)
            post.PostId = _posts.Max(p => p.PostId) + 1;
        else
            post.PostId = 1;

        _posts.Add(post);
        return await Task.FromResult(true);
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await Task.FromResult(_posts);
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        return await Task.FromResult(_posts.Find(p => p.PostId == id));
    }

    public async Task<bool> UpdateAsync(Post post)
    {
        var index = _posts.FindIndex(p => p.PostId == post.PostId);

        if (index < 0)
            return await Task.FromResult(false);

        _posts[index] = post;
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var index = _posts.FindIndex(p => p.PostId == id);

        if (index < 0)
            return await Task.FromResult(false);

        _posts.RemoveAt(index);
        return await Task.FromResult(true);
    }

    public async Task<bool> SaveAsync()
    {
        return true;
    }
}
