using FoodDelivery;
using FoodDelivery.Repositories.CourierRepo;
using FoodDelivery.Repositories.MenuRepo;
using FoodDelivery.Repositories.OrderRepo;
using FoodDelivery.Repositories.RestaurantRepo;
using FoodDelivery.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DeliveryAppDB")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ICourierReporitory, CourierRepository>();
builder.Services.AddScoped<IUserReporitory, UserRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();
app.UseHttpsRedirection();


app.Run();
