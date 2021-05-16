using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalyticsAdapter
{
    public class Repository : IRepository
    {
        private readonly IDatabase _db;

        public Repository(IDatabase db)
        {
            _db = db;
        }
        public void AddCustomer(string name)
        {
            if (_db.Customers.Any(x => x.Name == name))
            {
                throw new InvalidOperationException("Customer with the same name already exists");
            }
            _db.Customers.Add(new Customer(_db.Customers.Count + 1, name));
        }

        public void AddOrders(int customerId, int productId) //я не понял построения логики, для вызова эксепшена из if. != || != по логике, но не работает
        {
            if (_db.Customers.Any(x => x.Id == customerId)
                && _db.Products.Any(x => x.Id == productId))
            {
                _db.Orders.Add(new Order(_db.Orders.Count + 1, productId, customerId));
            }
            else
            {
                throw new InvalidOperationException("There is no such custom or product");
            }
        }

        internal void AddProduct(string name, decimal price)
        {
            if(_db.Products.Any(x => x.Name == name))
            {
                throw new InvalidOperationException("A product with the same name already exists");
            }
            _db.Products.Add(new Product(_db.Products.Count + 1, name, price));
        }

        public Order[] GetOrders(int customerId)  
        {
            var orders = _db.Orders.Where(order => order.CustomerId == customerId);
            if (orders == null)
            {
                throw new InvalidOperationException("Invalid customer ID: {customerId}");
            }
            return orders.ToArray();
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
               .Join(_db.Products, a => a.ProductId, b => b.Id, (a, b) => b);

            if (allProductPurchased == null)
            {
                throw new InvalidOperationException("Invalid id customer");
            }
            return allProductPurchased.ToArray();
        }

        public Product[] GetUniqueProductsPurchased(int customerId) 
        {
            var productPurchased = GetAllProductsPurchased(customerId).Distinct();
            return productPurchased.ToArray();
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
            var customerOverview = new CustomerOverview();

            customerOverview.Name = _db.Customers
                .Where(customer => customer.Id == customerId).Single().Name;

            customerOverview.TotalProductsPurchased =
                GetAllProductsPurchased(customerId).Count();

            customerOverview.FavoriteProductName =
                GetAllProductsPurchased(customerId)
                .GroupBy(x => x.Name)
                .Select(favorite => new { Name =
                favorite.Key, Count = favorite.Count() })
                .OrderByDescending(x => x.Count)
                .Select(x => x.Name)
                .First();

            customerOverview.MaxAmountSpentPerProducts =
                GetAllProductsPurchased(customerId)
                .GroupBy(x => x.Price)
                .Select(maxAmount => new { Price =
                maxAmount.Key, Count = maxAmount.Count() })
                .Max(x => x.Price * x.Count);

            customerOverview.TotalMoneySpent =
                GetAllProductsPurchased(customerId)
                .Select(x => x.Price)
                .Sum();

            return customerOverview;
        }

        public List<(string productName, int numberOfPurchases)> GetProductsPurchased(int customerId)
        {
            return GetAllProductsPurchased(customerId)
                .GroupBy(x => x.Name).
                Select(favorite => (favorite.Key, favorite.Count() ))
                .ToList();
        }
    }
}
