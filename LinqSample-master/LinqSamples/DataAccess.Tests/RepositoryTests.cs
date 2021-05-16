using System;
using AnalyticsAdapter;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace DataAccess.Tests
{
    public class RepositoryTests
    {
        private readonly IDatabase _db = new Database();

        public class FakeDatabase : IDatabase
        {
            public List<Customer> Customers { get; set; } = new List<Customer>();
            public List<Order> Orders { get; set; } = new List<Order>();
            public List<Product> Products { get; set; } = new List<Product>();
        }

        [Fact]
        public void AddCustomer_ForNonExistentingCustomer_returnExseption()
        {
            var repository = new Repository(_db);

            Action act = () => repository.AddCustomer("Mike");

            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void AddCustomrer_ForNonExistentingCustomer_ChecksTheIncreaseInSize()
        {
            var repository = new Repository(_db);

            var customerCount = _db.Customers.Count;
            repository.AddCustomer("Jora");

            _db.Customers.Should().HaveCount(customerCount + 1);
        }

        [Fact]
        public void AddCustomrer_ForNonExistentingCustomer_CheckingListWithNewCustomer()
        {
            var repository = new Repository(_db);

            repository.AddCustomer("Jora");

            _db.Customers.Should().BeEquivalentTo(new[]
            {
                new Customer(1, "Mike"),
                new Customer(2, "John"),
                new Customer(3, "Bob"),
                new Customer(4, "Nick"),
                new Customer(5, "Jack"),
                new Customer(6, "Jora")
            });
        }

        [Fact]
        public void AddOrders_ForExistentingCustomerAndOrder_ChecksTheIncreaseInSize()
        {
            var repository = new Repository(_db);

            var orderCount = _db.Orders.Count;
            repository.AddOrders(1, 1);

            _db.Orders.Should().HaveCount(orderCount + 1);
        }

        [Fact]
        public void AddOrders_ForNotExistentingCustomerAndValidOrder_returnExseption()
        {
            var repository = new Repository(_db);

            var orderCount = _db.Orders.Count;
            Action act = () => repository.AddOrders(1000, 1);

            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void AddOrders_ForNotExistentingOrderAndValidCustomer_returnExseption()
        {
            var repository = new Repository(_db);

            var orderCount = _db.Orders.Count;
            Action act = () => repository.AddOrders(1, 100);

            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void GetOrders_forNonExistingCustomer_returnsEmptyResult()
        {
            var repository = new Repository(_db);

            var orders = repository.GetOrders(1000);

            Assert.Empty(orders);
        }

        [Fact]
        public void GetOrders_forExistingCustomer_CheckingListWithNewOrder()
        {

            var repository = new Repository(_db);

            var orders = repository.GetOrders(1);

            orders.Should().BeEquivalentTo(new[]
            {
                new Order(1, 1, 1),
                new Order(2, 1, 1),
                new Order(3, 4, 1),
            });
        }

        [Fact]
        public void DidPurchaseAllProducts_forValidPurchasesAndExistingCustomer_returnTrue()
        {
            var repository = new Repository(_db);

            bool confirm = repository.DidPurchaseAllProducts(1,1,4);

            confirm.Should().BeTrue();
        }

        [Fact]
        public void DidPurchaseAllProducts_forInvalidPurchasesAndExistingCustomer_returnFalse()
        {
            var repository = new Repository(_db);

            bool confirm = repository.DidPurchaseAllProducts(1, 2, 4);

            confirm.Should().BeFalse();
        }

        [Fact]
        public void DidPurchaseAllProducts_forNonExistingCustomer_returnfalse()
        {
            var repository = new Repository(_db);

            bool confirm = repository.DidPurchaseAllProducts(1000, 1, 4);

            confirm.Should().BeFalse();
        }

        [Fact]
        public void GetCustomerOverview_ForNonExistentingCustomer_returnExseption() //   выкидывает ексепшен автоматически System.InvalidOperationException : Sequence contains no elements
        {
            var repository = new Repository(_db);

            Action act = () => repository.GetCustomerOverview(1000);

            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void GetCustomerOverview_forExistentingCustomer_returnOverviEwexistingCustomer()
        {
            var repository = new Repository(_db);

            var products = repository.GetCustomerOverview(1);

            products.Should().BeEquivalentTo(  new CustomerOverview
            {
                Name = "Mike",
                TotalProductsPurchased = 3,
                FavoriteProductName = "Phone",
                MaxAmountSpentPerProducts = 1000M,
                TotalMoneySpent = 1800M
                } );
        }

        [Fact]
        public void GetProductsPurchased_forNonExistingCustomer_returnsEmptyResult()
            {
                var repository = new Repository(_db);

                var products = repository.GetProductsPurchased(1000);

                products.Should().BeEmpty();
            }

            [Fact]
            public void GetProductsPurchased_forExistingCustomerWhoNotBuy_returnsEmptyResul()
            {
                var repository = new Repository(_db);

                var products = repository.GetProductsPurchased(5);

                products.Should().BeEmpty();
            }

            [Fact]
            public void GetProductsPurchased_forExistingCustomer_returnsEmptyResult()
            {
                var repository = new Repository(_db);

                var products = repository.GetProductsPurchased(1);

                products.Should().NotBeEmpty();
            }
        }
    } 
