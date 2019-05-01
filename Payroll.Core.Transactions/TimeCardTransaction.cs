using System;
using Payroll.Core.Domain;
using Payroll.Core.Classifications;

namespace Payroll.Core.Transactions
{
    public class TimeCardTransaction : ITransaction
    {
        private readonly int _employeeId;
        private readonly TimeCard _timeCard;

        public TimeCardTransaction(int employeeId, DateTime workingDate, double workingHours)
        {
            _employeeId = employeeId;
            _timeCard = new TimeCard(employeeId, workingDate, workingHours);
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
                    hc.AddTimeCard(_timeCard);
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