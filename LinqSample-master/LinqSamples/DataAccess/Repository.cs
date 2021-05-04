using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalyticsAdapter
{
    public class Repository : IRepository
    {
        private readonly Database _db;

        public Order[] GetOrders(int customerId)  //получаем список покупок по id пользователя
        {
            return _db.Orders.Where(order => order.CustomerId == customerId).ToArray();
        }

        public Order GetOrder(int orderId) // получаем покупку по её id
        {
            var order = _db.Orders.SingleOrDefault(order => order.Id == orderId);
            if(order == null)
            {
                throw new InvalidOperationException("Invalid id order");
            }
            return order;
        }
        public decimal GetMoneySpentBy(int customerId) //сумма денег, потраченая на покупки одним пользователем
        {
            return _db.Orders.Join(
                _db.Products,
                a => a.ProductId,
                b => b.Id,
                (a, b) => new
                {
                    Price = b.Price,
                    CustomerId = a.CustomerId
                }).Where(x => x.CustomerId == customerId)
                .Sum(x => x.Price);
        }
        public Product[] GetAllProductsPurchased(int customerId) //все купленые товары пользователя по id 
        {
            var productPurchased = GetOrders(customerId)
                .Join( _db.Products, a => a.ProductId, b => b.Id, (a, b) => b).Distinct()
                 .ToArray();
            if (productPurchased == null)
            {
                throw new InvalidOperationException("Invalid id customer");
            }
            return productPurchased;
        }
        public Product[] GetUniqueProductsPurchased(int customerId)
        {
            return GetOrders(customerId)
                .Join(_db.Products, (o) => o.ProductId, (p) => p.Id, (o, p) => p)
                .Distinct()
                .ToArray();
        }
    }
}
