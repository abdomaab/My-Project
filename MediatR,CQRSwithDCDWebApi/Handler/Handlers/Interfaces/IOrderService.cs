
using Domins.Models;

namespace Handlers.Interfaces
{
    public interface IOrderService
    {
        ValueTask<Order> ReadById(int id);
        ValueTask<IEnumerable<Order>> ReadAll();
        ValueTask<Order> Create(Order order);
        ValueTask<Order> Edit(Order order);
        ValueTask<Order> Delete(int id);
    }
}
