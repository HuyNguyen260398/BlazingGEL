using BlazingGEL.CoreBusiness.Models;
using BlazingGEL.Services.DataStoreInterfaces;

namespace BlazingGEL.DataStore.InMemory.Services;

public class CommentInMemoryRepository : ICommentRepository
{
    private static List<Comment> _comments = new()
    {
        new Comment { CommentId = 1, PostId = 1, Name = "Guest 1", Email = "guest1@gmail.com", Content = "Comment 1", CreatedAt = DateTime.Now },
        new Comment { CommentId = 2, PostId = 2, Name = "Guest 2", Email = "guest2@gmail.com", Content = "Comment 2", CreatedAt = DateTime.Now },
        new Comment { CommentId = 3, PostId = 3, Name = "Guest 3", Email = "guest3@gmail.com", Content = "Comment 3", CreatedAt = DateTime.Now }
    };

    public Task<IEnumerable<Comment>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostAsync(int postId)
    {
        return await Task.FromResult(_comments.Where(c => c.PostId == postId));
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(Comment comment)
    {
        if (_comments != null && _comments.Count() > 0)
            comment.CommentId = _comments.Max(c => c.CommentId) + 1;
        else
            comment.CommentId = 0;

        _comments.Add(comment);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(Comment comment)
    {
        var index = _comments.FindIndex(c => c.CommentId == comment.CommentId);

        if (index < 0)
            return await Task.FromResult(false);

        _comments[index] = comment;
        return await SaveAsync();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAsync()
    {
        return await Task.FromResult(true);
    }
}
