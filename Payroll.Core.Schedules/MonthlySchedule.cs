using System;
using Payroll.Core.Domain;

namespace Payroll.Core.Schedules
{
    public class MonthlySchedule : PaymentSchedule
    {
        public override bool IsPayDay(DateTime payDate)
        {
            return IsLastDayOfMonth(payDate);
        }

        private bool IsLastDayOfMonth(DateTime payDate)
        {
            int currentMonth = payDate.Month;
            int monthAfterOneDay = payDate.AddDays(1).Month;

            return monthAfterOneDay != currentMonth;
        }
    }
}