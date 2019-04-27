namespace Payroll.Core.Host
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