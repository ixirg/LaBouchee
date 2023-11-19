﻿using LaBouchee.Data;
using LaBouchee.Models.Interfaces;

namespace LaBouchee.Models.Services
{
    public class ProductRepository : iProductRepository
    {
        private LaBoucheeDbContext dbContext;
        public ProductRepository(LaBoucheeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products;
        }

        public Product? GetProductDetail(int id)
        {
            return dbContext.Products.FirstOrDefault(p=>p.Id==id);
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Products.Where(p=>p.isTrendingProduct);
        }
    }
}
