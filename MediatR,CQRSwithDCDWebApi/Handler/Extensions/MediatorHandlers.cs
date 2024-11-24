
using Handler.MediatorHandler.MediatorCommand.Carts;
using Handler.MediatorHandler.MediatorCommand.Categories;
using Handler.MediatorHandler.MediatorCommand.CustomProducts;
using Handler.MediatorHandler.MediatorCommand.Orders;
using Handler.MediatorHandler.MediatorCommand.Products;
using Handler.MediatorHandler.MediatorCommand.UserUploads;
using Handler.MediatorHandler.MediatorQuery.Carts;
using Handler.MediatorHandler.MediatorQuery.Categories;
using Handler.MediatorHandler.MediatorQuery.CustomProducts;
using Handler.MediatorHandler.MediatorQuery.Orders;
using Handler.MediatorHandler.MediatorQuery.Products;
using Handler.MediatorHandler.MediatorQuery.UserUploads;
using Microsoft.Extensions.DependencyInjection;

namespace Handler.Extensions
{
    public static class MediatorHandlers
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            // Registering Mediator Handlers for Cart
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddCartCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteCartCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateCartCommand>());            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateUserUploadCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetCartByIdQuery>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllCartsQuery>());


            // Registering Mediator Handlers for Category
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddCategoryCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteCategoryCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateCategoryCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetCategoryByIdQuery>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllCategoriesQuery>());


            // Registering Mediator Handlers for Order
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddOrderCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteOrderCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateOrderCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetOrderByIdQuery>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllOrdersQuery>());


            // Registering Mediator Handlers for Product
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddProductCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteProductrCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateProductCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetProductByIdQuery>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>());


            // Registering Mediator Handlers for CustomProduct
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddCustomProductCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteCustomProductCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateCustomProductCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetCustomProductByIdQuery>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllCustomProductsQuery>());

            // Registering Mediator Handlers for UserUpload
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddUserUploadCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteUserUploadCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateUserUploadCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetUserUploadByIdQuery>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllUserUploadsQuery>());
        }
    }
}
