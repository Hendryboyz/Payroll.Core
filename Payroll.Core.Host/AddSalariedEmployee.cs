namespace Payroll.Core.Host
{
    public class AddSalariedEmployee : AddEmployTransaction
    {
        private double _salary;

        public AddSalariedEmployee(int employeeId, string name, string address, double salaries) 
            : base(employeeId, name, address)
        {
            _salary = salaries;
        }

        protected override PaymentClassification GetPaymentClassification()
        {
            return new SalariedClassification(_salary);
        }

        protected override PaymentMethod GetPaymentMethod()
        {
            return new HoldMethod();
        }

        protected override PaymentSchedule GetPaymentSchedule()
        {
            return new MonthlySchedule();
        }
    }
}