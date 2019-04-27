namespace Payroll.Core.Host
{
    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private double _hourlyRate;

        public ChangeHourlyTransaction(
            int employeeId, double hourlyRate) : base(employeeId)
        {
            _hourlyRate = hourlyRate;
        }

        protected override PaymentClassification Classification 
        {
            get 
            {
                return new HourlyClassification(_hourlyRate);
            }
        }

        protected override PaymentSchedule Schedule 
        {
            get 
            {
                return new WeeklySchedule();
            }
        }
    }
}