using LaBouchee.Data;
using LaBouchee.Models.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace LaBouchee.Models.Services
{
    public class OrderRepository:iOrderRepository
    {
        private LaBoucheeDbContext dbContext;
        private iShoppingCartRepository shoppingCartRepository;
        public OrderRepository(LaBoucheeDbContext dbContext, iShoppingCartRepository shoppingCartRepository)
        {
            this.dbContext = dbContext;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public void PlaceOrder(Order order)
        {
            var shoppingCartItems=shoppingCartRepository.GetShoppingCartItems();
            order.OrderDetails = new List<OrderDetail>();
            foreach(var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity=item.Qty,
                    ProductId=item.Product.Id,
                    Price=item.Product.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            order.OrderPlaced=DateTime.Now;
            order.OrderTotal = shoppingCartRepository.GetShoppingCartTotal();
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }
    }
}
