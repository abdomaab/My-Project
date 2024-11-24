using Domins;
using Domins.Models;
using Handlers.Interfaces;

namespace Handlers.Services
{
    public class UserUploadService : IUserUploadService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<UserUpload> _repository;
        public UserUploadService(IRepository<UserUpload> repository, ApplicationDbContext context) 
        {
            _repository = repository;
            _context = context;
        }
        public async ValueTask<IEnumerable<UserUpload>> ReadAll()
        {
            return await _repository.GetAllAsync();
        }

        public async ValueTask<UserUpload> ReadById(int id)
        {
            return await _repository.GetByidAsync(id);
        }
        public async ValueTask<UserUpload> Create(UserUpload userUpload)
        {
            await _repository.AddAsync(userUpload);
            return userUpload;
        }

        public async ValueTask<UserUpload> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }

        public async ValueTask<UserUpload> Edit(UserUpload userUpload)
        {
            await _repository.UpdateAsync(userUpload);
            return userUpload;
        }
    }
}
