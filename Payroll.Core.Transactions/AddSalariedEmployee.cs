using Payroll.Core.Domain;
using Payroll.Core.Classifications;
using Payroll.Core.Schedules;

namespace Payroll.Core.Transactions
{
    public class AddSalariedEmployee : AddEmployTransaction
    {
        private readonly double _salary;

        public AddSalariedEmployee(int employeeId, string name, string address, double salaries) 
            : base(employeeId, name, address)
        {
            _salary = salaries;
        }

        protected override PaymentClassification CreatePaymentClassification()
        {
            return new SalariedClassification(_salary);
        }

        protected override PaymentSchedule CreatePaymentSchedule()
        {
            return new MonthlySchedule();
        }
    }
}