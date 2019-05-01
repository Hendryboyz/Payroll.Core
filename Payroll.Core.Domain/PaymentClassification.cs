using System;

namespace Payroll.Core.Domain
{
    public abstract class PaymentClassification
    {
        public abstract double CalculatePay(PayCheck payCheck);
    }
}