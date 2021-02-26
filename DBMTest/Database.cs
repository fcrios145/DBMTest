using System;
using System.Collections.Generic;

namespace DBMTest
{
    public static class Database
    {
        static List<Customer> customers = new List<Customer>();
        public static bool InitDb()
        {
            
            return true;
        }
        public static List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public static Customer AddCustomer(Customer customer)
        {
            customers.Add(customer);
            return customer;
        }
    }
}