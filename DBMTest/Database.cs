using System;
using System.Collections.Generic;

namespace DBMTest
{
    public static class Database
    {
        static List<Customer> customers = new List<Customer>();
        public static bool InitDb()
        {
            customers.Add(new Customer()
            {
                Name = "Jack",
                CreditCards = new List<CreditCard>()
                {
                    new CreditCard()
                    {
                        CreditCardNumber = "1234",
                        Balance = 0,
                        Limit = 100
                    },
                    new CreditCard()
                    {
                        CreditCardNumber = "5555",
                        Balance = 0,
                        Limit = 200
                    },
                    new CreditCard()
                    {
                        CreditCardNumber = "8241",
                        Balance = 0,
                        Limit = 300
                    },
                    new CreditCard()
                    {
                        CreditCardNumber = "0101",
                        Balance = 0,
                        Limit = 0
                    },
                    new CreditCard()
                    {
                        CreditCardNumber = "9610",
                        Balance = 0,
                        Limit = 0
                    },
                }
            });
            customers.Add(new Customer()
            {
                Name = "Jill",
                CreditCards = new List<CreditCard>()
                {
                    new CreditCard()
                    {
                        CreditCardNumber = "1234",
                        Balance = 0,
                        Limit = 500
                    },
                    new CreditCard()
                    {
                        CreditCardNumber = "5555",
                        Balance = 0,
                        Limit = 500
                    },
                    new CreditCard()
                    {
                        CreditCardNumber = "8241",
                        Balance = 0,
                        Limit = 600
                    },
                    new CreditCard()
                    {
                        CreditCardNumber = "2222",
                        Balance = 0,
                        Limit = 0
                    },
                    new CreditCard()
                    {
                        CreditCardNumber = "9999",
                        Balance = 0,
                        Limit = 0
                    },
                }
            });
            return true;
        }
        public static List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public static Customer FindCustomerByName(string name)
        {
            return customers.Find(x => x.Name == name);
        }

        public static bool DeleteCustomerByName(string name)
        {
            Customer customer = FindCustomerByName(name);
            customers.Remove(customer);
            return true;
        }

        public static Customer AddCustomer(Customer customer)
        {
            customers.Add(customer);
            return customer;
        }

        public static CreditCard FindCreditCardByNumber(string number, Customer customer)
        {
            return customers
                .Find(x => x.Name == customer.Name)
                .CreditCards
                .Find(x => x.CreditCardNumber == number);
        }

        public static bool DeleteCreditCardByNumber(string number, Customer customer)
        {
            CreditCard creditCard = FindCreditCardByNumber(number, customer);
            customer.CreditCards.Remove(creditCard);
            return true;
        }

        public static Customer AddCreditCard(CreditCard creditCard, string customerName)
        {
            Customer customer = FindCustomerByName(customerName);
            customer.CreditCards.Add(creditCard);
            return customer;
        }
    }
}