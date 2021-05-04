using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalyticsAdapter
{
    public class Repository : IRepository
    {
        private readonly Database _db;

        public Repository(Database db)
        {
            _db = db;
        }

        public Order[] GetOrders(int customerId)  //получаем список покупок по id пользователя
        {
            var orders = _db.Orders.Where(order => order.CustomerId == customerId).ToArray();
            if (orders == null)
            {
                throw new InvalidOperationException("Invalid id order");
            }
            return orders;
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

        public Product[] GetAllProductsPurchased(int customerId) // все купленые товары покупателя по id
        {
            var allProductPurchased = GetOrders(customerId)
               .Join(_db.Products, a => a.ProductId, b => b.Id, (a, b) => b)
                .ToArray();
            if (allProductPurchased == null)
            {
                throw new InvalidOperationException("Invalid id customer");
            }
            return allProductPurchased;
        }

        public Product[] GetUniqueProductsPurchased(int customerId) //все уникальные купленые товары пользователя по id 
        {
            var productPurchased = GetAllProductsPurchased(customerId).Distinct();
            return (Product[])productPurchased;
        }

        public int GetTotalProductsPurchased(int productId) //колличество покупок по id покупателя
        {
            var totalProducts = GetOrders(productId).Count();
            return totalProducts;
        }

        public bool HasEverPurchasedProduct(int customerId, int productId) //куплен ли продук покупателем. брал от уникальных покупок
        {
           var allProducts = GetUniqueProductsPurchased(customerId);
            return allProducts.Any(productId => true);
        }

        public bool AreAllPurchasesHigherThan(int customerId, decimal targetPrice) //все ли товары, купленые покупателем, выше заданной цены 
        {
            return GetOrders(customerId)
                .Join(_db.Products, a => a.ProductId, b => b.Id, (a, b) => b)
                .All(x => x.Price > targetPrice);
        }

        public bool DidPurchaseAllProducts(int customerId, params int[] productIds)
        {
            return GetOrders(customerId)
                .Select(x => x.ProductId)
                .Distinct()
                .Intersect(productIds).Count() == productIds.Count();
        }
    }
}
