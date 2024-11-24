using Handlers.Interfaces;
using Domins;
using Domins.Models;


namespace Handlers.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public readonly IRepository<Cart> _repository;
        public CartService(IRepository<Cart> repository, ApplicationDbContext context) 
        {
            _repository = repository;
            _context = context;
        }
        public async ValueTask<IEnumerable<Cart>> ReadAll()
        {
            return await _repository.GetAllAsync();
        }

        public async ValueTask<Cart> ReadById(int id)
        {
            return await _repository.GetByidAsync(id);
        }
        public async ValueTask<Cart> Create(Cart cart)
        {
            await _repository.AddAsync(cart);
            return cart;
        }
        public async ValueTask<Cart> Edit(Cart cart)
        {
            await _repository.UpdateAsync(cart);
            return cart;
        }
        public async ValueTask<Cart> Delete(int id)
        {
            
            return await _repository.DeleteAsync(id);
        }
    }
}
