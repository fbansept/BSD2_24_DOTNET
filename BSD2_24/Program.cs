using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BSD2_24.Data;
using BSD2_24.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BSD2_24Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BSD2_24Context") ?? throw new InvalidOperationException("Connection string 'BSD2_24Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
