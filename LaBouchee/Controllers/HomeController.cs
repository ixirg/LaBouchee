using LaBouchee.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaBouchee.Controllers
{
    public class HomeController : Controller
    {
        private iProductRepository productRepository;
        
        public HomeController(iProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(productRepository.GetTrendingProducts());
            
        }
    }
}
