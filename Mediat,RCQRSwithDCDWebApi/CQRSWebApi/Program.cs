using MediatR;
using Microsoft.Extensions.DependencyInjection;

using Domins;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Handler;
using Handler.Extensions;
using FluentValidation;
using Handler.UnityOfWork;
using Handler.Mediator;
using Handler.MediatorHandler.MediatorQueryHandler.CustomProducts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//var configuration = builder.Configuration;


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

//mediator and fluentvalidation
//builder.Services.RegisterHandlers();
builder.Services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(GetAllCustomProductsQueryHandler).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatorRequest<,>));

builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();
//builder.Services.AddTransient(typeof(IRepositoryQuery<>), typeof(RepositoryQuery<>));


//builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<ICustomProductService, CustomProductService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IUserUploadService, UserUploadService>();

//builder.Services.AddScoped<ICartQuery, CartQuery>();
//builder.Services.AddScoped<ICategoryQuery, CategoryQuery>();
//builder.Services.AddScoped<ICustomProductQuery, CustomProductQuery>();
//builder.Services.AddScoped<IOrderQuery, OrderQuery>();
//builder.Services.AddScoped<IProductQuery, ProductQuery>();
//builder.Services.AddScoped<IUserUploadQuery, UserUploadQuery>();


builder.Services.AddAutoMapper(typeof(MappingFiles));







builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });



builder.Services.AddControllers();

builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.HandelException();

app.UseCors(c => c.AllowAnyOrigin());
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
