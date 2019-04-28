using System;

namespace Payroll.Core.Host
{
    public abstract class PaymentSchedule
    {
        public abstract bool IsPayDay(DateTime payDate);
    }
}