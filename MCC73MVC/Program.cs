using MCC73MVC.Contexts;
using MCC73MVC.Repositories.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency
builder.Services.AddScoped<AccountRepositories>();
builder.Services.AddScoped<RoleRepositories>();
builder.Services.AddScoped<DivisionRepositories>();
builder.Services.AddScoped<DepartmentRepositories>();

// Sql Server
builder.Services.AddDbContext<MyContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

// Setup Session
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(15));

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
