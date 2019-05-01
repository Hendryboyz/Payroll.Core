using System;
using System.Collections;
using Payroll.Core.Domain;

namespace Payroll.Core.Schedules
{
    public class BiweeklySchedule : PaymentSchedule
    {
        public override bool IsPayDay(DateTime payDate)
        {
            bool isLastDayOfWeek = payDate.DayOfWeek == DayOfWeek.Friday;
            
            return isLastDayOfWeek && IsPayWeek(payDate);
        }

        private bool IsPayWeek(DateTime payDate)
        {
            ArrayList payWeekInYear = GetAllPayWeekThisYear(payDate);
            return payWeekInYear.Contains(payDate);
        }

        private ArrayList GetAllPayWeekThisYear(DateTime payDate)
        {
            DateTime firstFriday = GetFirstFridayThisYear(payDate);
            ArrayList payWeekInYear = new ArrayList();
            DateTime biweekPayDay = firstFriday.AddDays(7);
            while (biweekPayDay.Year == payDate.Year)
            {
                payWeekInYear.Add(biweekPayDay);
                biweekPayDay = biweekPayDay.AddDays(14);
            }
            return payWeekInYear;
        }

        private DateTime GetFirstFridayThisYear(DateTime payDate)
        {
            DateTime firstFriday = new DateTime(payDate.Year, 1, 1);
            while (firstFriday.DayOfWeek != DayOfWeek.Friday)
            {
                firstFriday = firstFriday.AddDays(1);
            }

            return firstFriday;
        }
    }
}