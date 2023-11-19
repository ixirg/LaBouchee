using LaBouchee.Models.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PayPal.Api;

namespace LaBouchee.Controllers
{
    public class ShoppingCartController : Controller
    {
        private iShoppingCartRepository shoppingCartRepository;
        private iProductRepository productRepository;
        public ShoppingCartController(iShoppingCartRepository shoppingCartRepository, iProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var items = shoppingCartRepository.GetShoppingCartItems();
            shoppingCartRepository.ShoppingCartItems = items;
            ViewBag.CartTotal = shoppingCartRepository.GetShoppingCartTotal();
            return View(items);
        }

        public RedirectToActionResult AddToShoppingCart(int pId)
        {
            var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);
            if (product != null)
            {
                shoppingCartRepository.AddToCart(product);
                int cartCount = shoppingCartRepository.GetShoppingCartItems().Count();
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pId)
        {
            var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);
            if (product != null)
            {
                shoppingCartRepository.RemoveFromCart(product);
                int cartCount = shoppingCartRepository.GetShoppingCartItems().Count();
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }
            return RedirectToAction("Index");
        }
    }
}

//        public ActionResult PaymentWithPaypal(string Cancel=null)
//        {
//            APIContext apiContext = PaypalConfiguration.GetAPIContext();
//            try
//            {
//                if(string.IsNullOrEmpty(payerId))
//                {
//                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/PaymentWithPaypal";
//                    var guid=Convert.ToString((new Random()).Next(100000));
//                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
//                    var links = createdPayment.links.GetEnumerator();
//                    string paypalRedirectUrl = null;
//                    while(links.MoveNext())
//                    {
//                        Links lnk =links.Current;
//                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
//                        {
//                            paypalRedirectUrl = lnk.href;
//                        }
//                    }
//                    SessionExtensions["payment"] = createdPayment.id;
//                    return Redirect(paypalRedirectUrl);
                
//                }
//                else
//                {
//                    var guid = Request.Params["guid"];
//                    var executedPayment = executedPayment(apiContext, payerId, Session["payment"] as string);
//                    if(executedPayment.state.ToLower() !="approved")
//                    {
//                        return View("FailureView");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return View("FailureView");
//            }
//            return View("SuccessView");
//        }
//        private PayPal.Api.Payment payment;
//        private Payment ExecutePayment(APIContext apiContext, string payerID, string paymentId)
//        {
//            var paymentExecution = new PaymentExecution()
//            {
//                payer_id = payerId;
//        };
//        this.payment=new Payment()
//            { id = paymentId
//                };
//        }
//     }
//}
