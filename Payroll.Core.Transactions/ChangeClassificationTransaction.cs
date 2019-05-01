using Payroll.Core.Domain;

namespace Payroll.Core.Transactions
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        public ChangeClassificationTransaction(int employeeId) : base(employeeId)
        {
        }

        protected override void Change(Employee employee)
        {
            employee.Classification = Classification;
            employee.Schedule = Schedule;
        }

        protected abstract PaymentClassification Classification { get; }
        protected abstract PaymentSchedule Schedule { get; }

       
    }
}