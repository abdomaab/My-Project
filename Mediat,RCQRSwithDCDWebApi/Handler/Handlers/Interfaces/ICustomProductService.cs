using Domins.Models;

namespace Handlers.Interfaces
{
    public interface ICustomProductService
    {
        ValueTask<CustomProduct> ReadById(int id);
        ValueTask<IEnumerable<CustomProduct>> ReadAll();
        ValueTask<CustomProduct> Create (CustomProduct customProduct);
        ValueTask<CustomProduct> Edit (CustomProduct customProduct);
        ValueTask<CustomProduct> Delete (int id);
    }
}
