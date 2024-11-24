using Domins.Models;


namespace Handlers.Interfaces
{
    public interface ICategoryService
    {
        ValueTask<Category> ReadById(int id);
        ValueTask<IEnumerable<Category>> ReadAll();
        ValueTask<Category> Create(Category category);
        ValueTask<Category> Edit(Category category);
        ValueTask<Category> Delete(int id);
    }
}
