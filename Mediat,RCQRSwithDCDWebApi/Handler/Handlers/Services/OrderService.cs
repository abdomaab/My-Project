using Domins;
using Domins.Models;
using Handlers.Interfaces;

namespace Handlers.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Order> _repository;
        public OrderService(IRepository<Order> repository, ApplicationDbContext context) 
        {
            _repository = repository;
            _context = context;
        }
        public async ValueTask<IEnumerable<Order>> ReadAll()
        {
            return await _repository.GetAllAsync();
        }

        public async ValueTask<Order> ReadById(int id)
        {
            return await _repository.GetByidAsync(id);
        }
        public async ValueTask<Order> Create(Order order)
        {
            await _repository.AddAsync(order);
            return order;
        }

        public async ValueTask<Order> Delete(int id)
        {
            var result =await _repository.DeleteAsync(id);
            return result;

        }

        public async ValueTask<Order> Edit(Order order)
        {
             await _repository.UpdateAsync(order);
            return order;
        }
    }
}
