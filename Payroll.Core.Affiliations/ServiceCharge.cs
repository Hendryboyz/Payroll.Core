using System;

namespace Payroll.Core.Affiliations
{
    public class ServiceCharge
    {
        public ServiceCharge(DateTime date, double amount)
        {
            Date = date;
            Amount = amount;
        }

        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}