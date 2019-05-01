using Payroll.Core.Domain;
using Payroll.Core.Methods;

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