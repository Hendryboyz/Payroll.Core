namespace Payroll.Core.Host
{
    public class ChangeSalariedTransation : ChangeClassificationTransaction
    {
        private double _salaried;

        public ChangeSalariedTransation(
            int employeeId, double salaried) : base(employeeId)
        {
            _salaried = salaried;
        }

        protected override PaymentClassification Classification
        {
            get
            {
                return new SalariedClassification(_salaried);
            }
        }

        protected override PaymentSchedule Schedule
        {
            get
            {
                return new MonthlySchedule();
            }
        }
    }
}