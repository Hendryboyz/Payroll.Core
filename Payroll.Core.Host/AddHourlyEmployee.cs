using Payroll.Core.Domain;

namespace Payroll.Core.Host
{
    public class AddHourlyEmployee : AddEmployTransaction
    {
        private readonly double _hourlyRate;

        public AddHourlyEmployee(int employeeId, string name, string address, double hourlyRate)
            : base(employeeId, name, address)
        {
            _hourlyRate = hourlyRate;
        }
        protected override PaymentClassification CreatePaymentClassification()
        {
            return new HourlyClassification(_hourlyRate);
        }

        protected override PaymentSchedule CreatePaymentSchedule()
        {
            return new WeeklySchedule();
        }
    }
}