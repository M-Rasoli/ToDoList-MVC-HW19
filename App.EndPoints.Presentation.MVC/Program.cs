using System.Reflection;
using App.Domain.AppService.CategoryAgg;
using App.Domain.AppService.TodoListAgg;
using App.Domain.AppService.UserAgg;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.TodoListAgg.Contracts;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Services.CategoryAgg;
using App.Domain.Services.TodoListAgg;
using App.Domain.Services.UserAgg;
using App.Infrastructure.Persistence;
using App.Infrastructure.Repositories.CategoryAgg;
using App.Infrastructure.Repositories.TodoListAgg;
using App.Infrastructure.Repositories.UserAgg;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=DESKTOP-I05OKD5\SQLEXPRESS;Database=TodoList-MVC;Integrated Security=true;TrustServerCertificate=true;"));

builder.Services.AddSession();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<ITodoAppService,TodoAppService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
