using Domins;
using Domins.Models;
using Handlers.Interfaces;


namespace Handlers.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository, ApplicationDbContext context) 
        {
            _repository = repository;
            _context = context;
        }
        public async ValueTask<IEnumerable<Category>> ReadAll()
        {
            return await _repository.GetAllAsync();
        }

        public async ValueTask<Category> ReadById(int id)
        {
            return await _repository.GetByidAsync(id);
        }
        public async ValueTask<Category> Create(Category category)
        {
            await _repository.AddAsync(category);
            return category;
        }
        public async ValueTask<Category> Edit(Category category)
        {
            await _repository.UpdateAsync(category);
            return category;
        }
        public async ValueTask<Category> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }
    }
}
