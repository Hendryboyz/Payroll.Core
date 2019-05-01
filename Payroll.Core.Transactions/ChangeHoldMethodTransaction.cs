using Payroll.Core.Domain;

namespace Payroll.Core.Transactions
{
    public class ChangeHoldMethodTransaction : ChangePaymentMethodTransaction
    {
        public ChangeHoldMethodTransaction(int employeeId) : base(employeeId)
        {
        }

        public override PaymentMethod PaymentMethod
        {
            get
            {
                return new HoldMethod();
            }
        }
    }
}