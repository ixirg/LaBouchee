using LaBouchee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LaBouchee.Data
{
    public class LaBoucheeDbContext : IdentityDbContext
    {
        public LaBoucheeDbContext(DbContextOptions<LaBoucheeDbContext>options): base(options)
        {

        }
        public  DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem>ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails {  get; set; }    
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Pain au Chocolat", Detail = "Delicate layers of buttery, flaky pastry embrace a rich chocolate center, creating a blissful harmony of textures and flavors.", Price = 3, isTrendingProduct = true, ImageUrl = "https://i.postimg.cc/J0sq4xP1/Painauchocolat.jpg" },
                new Product { Id = 2, Name = "Croissant", Detail = " Handcrafted to golden buttery perfection, each layer unfolds with a crisp exterior and a soft, airy interior.", Price = 2, isTrendingProduct = true, ImageUrl = "https://i.postimg.cc/sg7Thnyx/Croissant.jpg" },
                new Product { Id = 3, Name = "Quiche", Detail = "A symphony of flaky crust and velvety filling, our handcrafted quiches are a delightful blend of premium ingredients.", Price = 5, isTrendingProduct = true, ImageUrl = "https://i.postimg.cc/wvf2pZ5f/Quiche.jpg" },
                new Product { Id = 4, Name = "Eclair", Detail = "Delicate choux pastry embraces a velvety center, each bite a symphony of textures and flavors.", Price = 3, isTrendingProduct = true, ImageUrl = "https://i.postimg.cc/tg4cKL8f/Eclair.jpg" },
                new Product { Id = 5, Name = "Mille-Feuille", Detail = "Layers of flaky puff pastry and luscious pastry cream.", Price = 3, isTrendingProduct = true, ImageUrl = "https://i.postimg.cc/TYxt8zD9/Millefeuille.jpg" },
                new Product { Id = 6, Name = "Madeleines", Detail = "Savor the charm of our Madeleines — petite, shell-shaped cakes with a soft, buttery texture.", Price = 1, isTrendingProduct = true, ImageUrl = "https://i.postimg.cc/vHv3G07d/Madeleines.jpg" },
                new Product { Id = 7, Name = "Macaron", Detail = "These delicate almond meringue cookies, with a crisp exterior and a luscious filling, promise a burst of flavor in every bite.", Price = 3, isTrendingProduct = true, ImageUrl = "https://i.postimg.cc/c1wFbxrC/Macarons.jpg" }
                );
        }
        
    }
}
