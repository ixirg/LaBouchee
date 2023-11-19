using LaBouchee.Models.Interfaces;
using LaBouchee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace LaBouchee.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private iOrderRepository orderRepository;
        private iShoppingCartRepository shoppingCartRepository;
        public OrdersController(iOrderRepository orderRepository, iShoppingCartRepository shoppingCartRepository)
        { 
            this.orderRepository = orderRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            orderRepository.PlaceOrder(order);
            shoppingCartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);
            return RedirectToAction("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}
