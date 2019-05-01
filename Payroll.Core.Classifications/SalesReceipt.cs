using System;

namespace Payroll.Core.Classifications
{
    public class SalesReceipt
    {
        public int EmployeeId;
        public DateTime WorkingDate;
        public int Amount;

        public SalesReceipt(int employeeId, DateTime workingDate, int amount)
        {
            EmployeeId = employeeId;
            WorkingDate = workingDate;
            Amount = amount;
        }
    }
}