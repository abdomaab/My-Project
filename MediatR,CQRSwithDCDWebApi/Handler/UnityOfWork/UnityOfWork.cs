using Domins;
using Domins.Models;
using Handlers;


namespace Handler.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnityOfWork(ApplicationDbContext context)
        {
            _context = context;
            Carts = new Repository<Cart>(_context);
            Orders = new Repository<Order>(_context);
            Categories = new Repository<Category>(_context);
            CustomProducts = new Repository<CustomProduct>(_context);
            Products = new Repository<Product>(_context);
            UserUploads = new Repository<UserUpload>(_context);
        }
        public IRepository<Cart> Carts { get; private set; }

        public IRepository<Order> Orders { get; private set; }

        public IRepository<Category> Categories { get; private set; }

        public IRepository<CustomProduct> CustomProducts { get; private set; }

        public IRepository<Product> Products { get; private set; }

        public IRepository<UserUpload> UserUploads { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
