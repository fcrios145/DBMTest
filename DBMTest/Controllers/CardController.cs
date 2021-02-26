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
    public class CardController : ControllerBase
    {
        [HttpPost("charge")]
        public ResponseCardCharge Charge(CardCharge cardCharge)
        {
            Customer customer = Database.FindCustomerByName(cardCharge.CustomerName);
            CreditCard creditCard = Database.FindCreditCardByNumber(cardCharge.CreditCardNumber, customer);
            double finalResult = cardCharge.AmountToCharge + creditCard.Balance;
            if(finalResult > creditCard.LimitAvailable)
            {
                return new ResponseCardCharge() { Reason = "Limit exceed", success = false };
            }
            if(Database.DeleteCreditCardByNumber(creditCard.CreditCardNumber, customer))
            {
                creditCard.Balance = finalResult;
                Database.AddCreditCard(creditCard, customer.Name);
            }

            return new ResponseCardCharge() { success = true };
        }
    }
}
