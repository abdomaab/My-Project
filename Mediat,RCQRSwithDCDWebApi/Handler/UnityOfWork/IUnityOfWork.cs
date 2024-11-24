using Handlers;
using Domins.Models;


namespace Handler.UnityOfWork
{
    public interface IUnityOfWork : IDisposable
    {
        IRepository<Cart> Carts { get; }
        IRepository<Order> Orders { get; }
        IRepository<Category> Categories { get; }
        IRepository<CustomProduct> CustomProducts { get; }
        IRepository<Product> Products { get; }
        IRepository<UserUpload> UserUploads { get; }
        int Complete();
    }
}
