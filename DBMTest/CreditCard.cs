﻿using System;
namespace DBMTest
{
    public class CreditCard
    {
        public string Number { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
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
                for (int i = 0; i < Number.Length; i++)
                {
                    sum += Convert.ToInt32(char.GetNumericValue(Number[i]));
                }
                switch (sum)
                {
                    case 10:
                        return "VISA";
                    case 20:
                        return "AMERICAN EXPRESS";
                    case 15:
                        return "MASTER CARD";
                    default:
                        break;
                }
                return "NOT FOUND";
            }
        }
    }
}