using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticsAdapter
{
    public interface IDatabase
    {
            List<Customer> Customers { get; set; }
            List<Order> Orders { get; set; }
            List<Product> Products { get; set; }

    }
}
