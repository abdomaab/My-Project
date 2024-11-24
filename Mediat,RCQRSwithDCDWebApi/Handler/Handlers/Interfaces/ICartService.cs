
using Domins.Models;


namespace Handlers.Interfaces
{
    public interface ICartService
    {
        ValueTask<Cart> ReadById(int id);
        ValueTask<IEnumerable<Cart>> ReadAll();
        ValueTask<Cart> Create(Cart cart);
        ValueTask<Cart> Edit(Cart cart);
        ValueTask<Cart> Delete(int id);
    }
}
