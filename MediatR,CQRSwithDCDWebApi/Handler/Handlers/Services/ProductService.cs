using Domins;
using Domins.Models;
using Handlers.Interfaces;

namespace Handlers.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository, ApplicationDbContext context) 
        {
            _repository = repository;
            _context = context;
        }

        public async ValueTask<Product> Create(Product product)
        {
            await _repository.AddAsync(product);
            return product;
        }

        public async ValueTask<Product> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }

        public async ValueTask<Product> Edit(Product product)
        {
            await _repository.UpdateAsync(product);
            return product;
        }

        public async ValueTask<IEnumerable<Product>> ReadAll()
        {
            return await _repository.GetAllAsync();
        }

        public async ValueTask<Product> ReadById(int id)
        {
            return await _repository.GetByidAsync(id);
        }
    }
}
    
