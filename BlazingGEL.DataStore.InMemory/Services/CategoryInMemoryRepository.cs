using BlazingGEL.CoreBusiness.Models;
using BlazingGEL.Services.DataStoreInterfaces;

namespace BlazingGEL.DataStore.InMemory.Services;

public class CategoryInMemoryRepository : ICategoryRepository
{
    private static List<Category> _categories = new()
    {
        new Category { CategoryId = 1, Name = "Category 1", Slug = "category_1" },
        new Category { CategoryId = 2, Name = "Category 2", Slug = "category_2" },
        new Category { CategoryId = 3, Name = "Category 3", Slug = "category_3" },
    };

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await Task.FromResult(_categories);
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await Task.FromResult(_categories.Find(c => c.CategoryId == id));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await Task.FromResult(_categories.Any(c => c.CategoryId == id));
    }

    public async Task<bool> CreateAsync(Category category)
    {
        if (_categories.Any(c => c.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
            return await Task.FromResult(false);

        if (_categories != null && _categories.Count > 0)
            category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
        else
            category.CategoryId = 1;

        _categories.Add(category);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        var index = _categories.FindIndex(c => c.CategoryId == category.CategoryId);

        if (index < 0)
            return await Task.FromResult(false);

        _categories[index] = category;
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var index = _categories.FindIndex(c => c.CategoryId == id);

        if (index < 0)
            return await Task.FromResult(false);

        _categories.RemoveAt(index);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await Task.FromResult(true);
    }
}
