using System;

namespace Payroll.Core.Host
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
            HourlyClassification hc = e.Classification as HourlyClassification;
            hc.AddTimeCard(_timeCard);
        }
    }
}