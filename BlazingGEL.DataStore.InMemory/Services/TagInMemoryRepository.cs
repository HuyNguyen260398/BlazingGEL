using BlazingGEL.CoreBusiness.Models;
using BlazingGEL.Services.DataStoreInterfaces;

namespace BlazingGEL.DataStore.InMemory.Services;

public class TagInMemoryRepository : ITagRepository
{
    private static List<Tag> _tags = new()
    {
        new Tag { TagId = 1, Name = "Tag 1", Slug = "tag-1" },
        new Tag { TagId = 2, Name = "Tag 2", Slug = "tag-2" },
        new Tag { TagId = 3, Name = "Tag 3", Slug = "tag-3" },
    };

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await Task.FromResult(_tags);
    }

    public async Task<Tag> GetByIdAsync(int id)
    {
        return await Task.FromResult(_tags.Find(t => t.TagId == id));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await Task.FromResult(_tags.Any(t => t.TagId == id));
    }

    public async Task<bool> CreateAsync(Tag tag)
    {
        if (_tags.Any(c => c.Name.Equals(tag.Name, StringComparison.OrdinalIgnoreCase)))
            return await Task.FromResult(false);

        if (_tags != null && _tags.Count > 0)
            tag.TagId = _tags.Max(t => t.TagId) + 1;
        else
            tag.TagId = 1;

        _tags.Add(tag);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(Tag tag)
    {
        var index = _tags.FindIndex(t => t.TagId == tag.TagId);

        if (index < 0)
            return await Task.FromResult(false);

        _tags[index] = tag;
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var index = _tags.FindIndex(t => t.TagId == id);

        if (index < 0)
            return await Task.FromResult(false);

        _tags.RemoveAt(index);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await Task.FromResult(true);
    }
}
