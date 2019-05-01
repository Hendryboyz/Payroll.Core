using Payroll.Core.Domain;

namespace Payroll.Core.Host
{
    public abstract class ChangePaymentMethodTransaction : ChangeEmployeeTransaction
    {
        public ChangePaymentMethodTransaction(int employeeId) : base(employeeId)
        {
        }

        protected override void Change(Employee employee)
        {
            employee.Method = PaymentMethod;
        }

        public abstract PaymentMethod PaymentMethod { get; }
    }
}