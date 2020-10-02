using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApp
{
    static class PaymentCalculator
    {
        public static double CalculateTotal(int price, double interest, int years)
        {
            int months = years * 12;
            //double payment = (price * (1 + (interest / 12) * months)) / months; //old payment formula
            double rate = interest / 12;
            double payment = price * Math.Pow(1 + rate, months);
            return Math.Ceiling((payment) * 100) / 100;
        }
    }
}
