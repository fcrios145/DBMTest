using System;
namespace DBMTest
{
    public class CreditCard
    {
        public string CreditCardNumber { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public string ValidCreditCardNumber
        { get
          {
                int sum = 0;
                for (int i = 0; i < CreditCardNumber.Length; i++)
                {
                    sum += Convert.ToInt32(char.GetNumericValue(CreditCardNumber[i]));
                }
                if(sum == 20 || sum == 10 || sum == 15)
                {
                    return "VALID";
                }
                return "INVALID";
            }
        }
        public string CreditCardNamePlusType
        {
            get
            {
                return $"{CreditCardNumber} - {Type}";
            }
        }
        public double LimitAvailable { 
            get
            {
                if(Type.Equals("AMERICAN EXPRESS"))
                {
                    return Limit * .90;
                } else
                {
                    return Limit;
                }
                
            }
        }
        public string Type
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < CreditCardNumber.Length; i++)
                {
                    sum += Convert.ToInt32(char.GetNumericValue(CreditCardNumber[i]));
                }
                if(sum <= 10)
                {
                    return "VISA";
                } else if(sum <= 15)
                {
                    return "MASTER CARD";
                } else
                {
                    return "AMERICAN EXPRESS";
                }
            }
        }
    }
}
