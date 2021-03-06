using System;
using Payroll.Core.Domain;

namespace Payroll.Core.Schedules
{
    public class WeeklySchedule : PaymentSchedule
    {
        public override bool IsPayDay(DateTime payDate)
        {
            DayOfWeek currentDayOfWeek = payDate.DayOfWeek;
            return DayOfWeek.Friday.Equals(currentDayOfWeek);
        }
    }
}