using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBMTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        // GET: /<controller>/
        public List<Customer> Get()
        {
            return Database.GetAllCustomers();
        }

        [HttpPost]
        public Customer Add(Customer customer)
        {
            return Database.AddCustomer(customer);
        }
    }
}
