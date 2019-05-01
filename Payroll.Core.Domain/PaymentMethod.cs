using System;

namespace Payroll.Core.Domain
{
    public abstract class PaymentMethod
    {
        public abstract void Pay(PayCheck payCheck);
    }
}