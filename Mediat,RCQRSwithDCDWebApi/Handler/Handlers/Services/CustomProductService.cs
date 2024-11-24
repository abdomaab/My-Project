using Domins;
using Domins.Models;
using Handlers.Interfaces;


namespace Handlers.Services
{
    public class CustomProductService : ICustomProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<CustomProduct> _repository;
        public CustomProductService(IRepository<CustomProduct> repository, ApplicationDbContext context) 
        {
            _repository = repository;
            _context = context;
        }
        public async ValueTask<IEnumerable<CustomProduct>> ReadAll()
        {
            return await _repository.GetAllAsync();
        }

        public async ValueTask<CustomProduct> ReadById(int id)
        {
            return await _repository.GetByidAsync(id);
        }
        public async ValueTask<CustomProduct> Create(CustomProduct customProduct)
        {
            await _repository.AddAsync(customProduct);
            return customProduct;
        }

        public async ValueTask<CustomProduct> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }

        public async ValueTask<CustomProduct> Edit(CustomProduct customProduct)
        {
            await _repository.UpdateAsync(customProduct);
            return customProduct;
        }
    }
}
