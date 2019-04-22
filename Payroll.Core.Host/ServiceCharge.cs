using System;

namespace Payroll.Core.Host
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