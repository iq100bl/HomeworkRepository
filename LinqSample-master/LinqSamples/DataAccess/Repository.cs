using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalyticsAdapter
{
    public class Repository : IRepository
    {
        private readonly Database _db;
        private CustomerOverview customerOverview;

        public Repository(Database db)
        {
            _db = db;
        }

        public Order[] GetOrders(int customerId)  
        {
            var orders = _db.Orders.Where(order => order.CustomerId == customerId).ToArray();
            if (orders == null)
            {
                throw new InvalidOperationException("Invalid id order");
            }
            return orders;
        }

        public Order GetOrder(int orderId) 
        {
            var order = _db.Orders.SingleOrDefault(order => order.Id == orderId);
            if (order == null)
            {
                throw new InvalidOperationException("Invalid id order");
            }
            return order;
        }

        public decimal GetMoneySpentBy(int customerId) 
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

        public Product[] GetAllProductsPurchased(int customerId) 
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

        public Product[] GetUniqueProductsPurchased(int customerId) 
        {
            var productPurchased = GetAllProductsPurchased(customerId).Distinct();
            return (Product[])productPurchased;
        }

        public int GetTotalProductsPurchased(int productId) 
        {
            var totalProducts = GetOrders(productId).Count();
            return totalProducts;
        }

        public bool HasEverPurchasedProduct(int customerId, int productId) 
        {
            var allProducts = GetUniqueProductsPurchased(customerId);
            return allProducts.Any(productId => true);
        }

        public bool AreAllPurchasesHigherThan(int customerId, decimal targetPrice) 
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
                .Intersect(productIds)
                .Count() == productIds.Count();
        }

        public CustomerOverview GetCustomerOverview(int customerId)
        {
            if (customerId > _db.Customers.Count() || customerId < 0)
            {
                throw new InvalidOperationException("Invalid Id customer");
            }

            customerOverview.Name = _db.Customers
                .Where(customer => customer.Id == customerId).First().Name;

            customerOverview.TotalProductsPurchased =
                GetAllProductsPurchased(customerId).Count();

            customerOverview.FavoriteProductName =
                GetAllProductsPurchased(customerId)
                .GroupBy(x => x.Name).
                Select(favorite => new { Name = favorite.Key, Count = favorite.Count() })
                .OrderByDescending(x => x.Count)
                .Select(x => x.Name)
                .First();

            customerOverview.MaxAmountSpentPerProducts =
                GetAllProductsPurchased(customerId)
                .GroupBy(x => x.Price)
                .Select(maxAmount => new { Price = maxAmount.Key, Count = maxAmount.Count() })
                .Max(x => x.Price * x.Count);

            customerOverview.TotalMoneySpent =
                GetAllProductsPurchased(customerId)
                .Select(x => x.Price)
                .Sum();

            return customerOverview;
        }

        public List<(string productName, int numberOfPurchases)> GetProductsPurchased(int customerId)
        {
            var x = GetAllProductsPurchased(customerId)
                .GroupBy(x => x.Name).
                Select(favorite => new { Name = favorite.Key, Count = favorite.Count() })
                .ToList();
           return (List<(string productName, int numberOfPurchases)>)x.Cast<(string productName, int numberOfPurchases)>(); // только так нашёл. 
        }
    }
}
