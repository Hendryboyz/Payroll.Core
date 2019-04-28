using System;

namespace Payroll.Core.Host
{
    public abstract class PaymentClassification
    {
        public abstract double CalculatePay(PayCheck payCheck);
    }
}