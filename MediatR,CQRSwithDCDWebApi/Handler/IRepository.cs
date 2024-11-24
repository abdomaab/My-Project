

using Domins.Models;
using Handler.Dto;
using Handler.MediatorHandler.MediatorCommand.Carts;

namespace Handlers
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T> GetByidAsync(int id);
        ValueTask<IEnumerable<T>> GetAllAsync();
        ValueTask<T> AddAsync(T entity);
        ValueTask<T> UpdateAsync(T entity);
        ValueTask<T> DeleteAsync(int id);
        //Task<CartDto> AddAsync(Cart cart);
        //Task<CartDto> UpdateAsync(CartDto cart);
        //Task<Cart> DeleteAsync(DeleteCartCommand request);
        //Task<Cart> DeleteAsync(ValueTask<CartDto> found);
        //Task<Cart> DeleteAsync(ValueTask<CartDto> found);
        //Task<Category> DeleteAsync(ValueTask<Category> find);
        //Task<CategoryDto> UpdateAsync(CategoryDto category);
        //Task<CustomProduct> DeleteAsync(ValueTask<CustomProduct> find);
        //Task UpdateAsync(CustomProductDto custom);
        //Task<Order> DeleteAsync(ValueTask<Order> find);
        //Task UpdateAsync(OrderDto order);
        //Task AddAsync(Product product);
        //Task<Product> DeleteAsync(ValueTask<Product> find);
        //Task UpdateAsync(ProductDto product);
        //Task<UserUpload> DeleteAsync(ValueTask<UserUpload> find);
        //Task UpdateAsync(UserUploadDto user);
    }
}
