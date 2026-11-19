using API.Controllers;
using CORE.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IProductRepository, ProductsRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<StoreContext>();
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
	throw;
}



app.Run();



//IProductRepository is the menu. It lists what you can order, but it can’t cook anything.
//ProductsRepository is the kitchen. It actually makes everything on the menu, using the database (the pantry).
//wProductsController is the waiter. It takes the customer’s order (the HTTP request), passes it to the kitchen, and brings the food back (the JSON response).