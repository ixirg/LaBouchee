using LaBouchee.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaBouchee.Controllers
{
    public class ProductsController : Controller
    {
        private iProductRepository productRepository;
        public ProductsController(iProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Shop()
        {
            return View(productRepository.GetAllProducts());
        }

        public IActionResult Detail(int id)
        {
            var product = productRepository.GetProductDetail(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
