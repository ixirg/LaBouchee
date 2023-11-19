using LaBouchee.Data;
using LaBouchee.Models.Interfaces;
using LaBouchee.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LaBouchee.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<iProductRepository, ProductRepository>();

builder.Services.AddScoped<iShoppingCartRepository, ShoppingCartRepository>(ShoppingCartRepository.GetCart);
builder.Services.AddScoped<iOrderRepository, OrderRepository>();

builder.Services.AddDbContext<LaBoucheeDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("LaBoucheeDbContextConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<LaBoucheeDbContext>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();

//DI
builder.Services.AddDbContext<IngredientsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LaBoucheeDbContextConnection"))
);

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();


app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
