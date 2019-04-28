using System;

namespace Payroll.Core.Host
{
    public abstract class PaymentMethod
    {
        public abstract void Pay(PayCheck payCheck);
    }
}