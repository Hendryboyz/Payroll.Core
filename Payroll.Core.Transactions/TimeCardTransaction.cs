using System;
using Payroll.Core.Domain;
using Payroll.Core.Classifications;
using Payroll.Core.DataBase;

namespace Payroll.Core.Transactions
{
    public class TimeCardTransaction : ITransaction
    {
        private readonly int _employeeId;
        private readonly DateTime _workingDate;
        private readonly double _workingHours;

        public TimeCardTransaction(int employeeId, DateTime workingDate, double workingHours)
        {
            _employeeId = employeeId;
            _workingDate = workingDate;
            _workingHours = workingHours;
        }

        public void Execute()
        {
            Employee e = PayrollRepository.GetEmployee(_employeeId);
            if (e != null)
            {
                HourlyClassification hc = e.Classification as HourlyClassification;
                bool isHourlyEmployee = hc != null;
                if (isHourlyEmployee)
                {
                    hc.AddTimeCard(_employeeId, _workingDate, _workingHours);
                }
                else
                {
                    throw new InvalidOperationException("non-hourly employee");
                }
            }
            else
            {
                throw new InvalidOperationException("No such employee.");
            }
        }
    }
}