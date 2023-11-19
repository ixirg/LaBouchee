namespace LaBouchee.Models.Interfaces
{
    public interface iProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetTrendingProducts();

        Product? GetProductDetail(int id);
    }
}
