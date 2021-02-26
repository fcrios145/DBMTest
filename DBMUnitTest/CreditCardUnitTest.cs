using System;
using DBMTest;
using Xunit;

namespace DBMUnitTest
{
    public class CreditCardUnitTest
    {
        [Fact]
        public void TestTypes()
        {
            CreditCard creditCardVisa = new CreditCard() { CreditCardNumber = "1234" };
            CreditCard creditCardAmericanExpreess = new CreditCard() { CreditCardNumber = "5555" };
            CreditCard creditCardMasterCard = new CreditCard() { CreditCardNumber = "8250" };
            CreditCard creditCardNotFound = new CreditCard() { CreditCardNumber = "0101" };


            Assert.Equal("VISA", creditCardVisa.Type);
            Assert.Equal("MASTER CARD", creditCardMasterCard.Type);
            Assert.Equal("AMERICAN EXPRESS", creditCardAmericanExpreess.Type);
            Assert.Equal("VISA", creditCardNotFound.Type);
        }

        [Fact]
        public void TestValidCreditCardType()
        {
            CreditCard creditCardVisa = new CreditCard() { CreditCardNumber = "2222" };
            CreditCard creditCardAmericanExpreess = new CreditCard() { CreditCardNumber = "5555" };

            Assert.Equal("INVALID", creditCardVisa.ValidCreditCardNumber);
            Assert.Equal("VALID", creditCardAmericanExpreess.ValidCreditCardNumber);

        }

        [Fact]
        public void TestLimitAvailable()
        {
            CreditCard creditCardVisa = new CreditCard() { CreditCardNumber = "1234", Limit = 100 };
            CreditCard creditCardMasterCard = new CreditCard() { CreditCardNumber = "8250", Limit = 1000 };
            CreditCard creditCardAmericanExpreess = new CreditCard() { CreditCardNumber = "5555", Limit = 200 };

            Assert.Equal(100, creditCardVisa.LimitAvailable);
            Assert.Equal(1000, creditCardMasterCard.LimitAvailable);
            Assert.Equal(180, creditCardAmericanExpreess.LimitAvailable);
            
        }
    }
}
