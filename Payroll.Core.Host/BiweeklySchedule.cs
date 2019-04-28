using System;

namespace Payroll.Core.Host
{
    public class BiweeklySchedule : PaymentSchedule
    {
        public override bool IsPayDay(DateTime payDate)
        {
            return true;
        }
    }
}