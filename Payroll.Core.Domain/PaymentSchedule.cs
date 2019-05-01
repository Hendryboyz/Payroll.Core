using System;

namespace Payroll.Core.Domain
{
    public abstract class PaymentSchedule
    {
        public abstract bool IsPayDay(DateTime payDate);
    }
}