using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApp
{
    static class PaymentCalculator
    {
        public static double CalculateMonthly(int price, double interest, int months)
        {
            double payment = (price * (1 + (interest / 12) * months)) / months;
            return Math.Ceiling(payment * 100) / 100;
        }
    }
}
