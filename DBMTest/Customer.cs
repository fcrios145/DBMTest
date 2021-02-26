using System;
using System.Collections.Generic;

namespace DBMTest
{
    public class Customer
    {
        public string Name { get; set; }
        public List<CreditCard> CreditCards { get; set; }
            
        public Customer()
        {
            CreditCards = new List<CreditCard>();
        }
    }
}
