using System;

namespace Payroll.Core.Host
{
    public class TimeCard
    {
        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public double Hours { get; set; }

        public TimeCard(int employeeId, DateTime workingDate, double workingHours)
        {
            EmployeeId = employeeId;
            Date = workingDate;
            Hours = workingHours;
        }
    }
}