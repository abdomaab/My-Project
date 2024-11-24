
using Domins.Models;

namespace Handlers.Interfaces
{
    public interface IProductService
    {
        ValueTask<Product> ReadById(int id);
        ValueTask<IEnumerable<Product>> ReadAll();
        ValueTask<Product> Create(Product product);
        ValueTask<Product> Edit(Product product);
        ValueTask<Product> Delete(int id);
    }
}
