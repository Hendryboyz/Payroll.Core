using Payroll.Core.Domain;

namespace Payroll.Core.Methods
{
    public class HoldMethod : PaymentMethod
    {
        public override void Pay(PayCheck payCheck)
        {
            payCheck.SetField("Disposition", "Hold");
        }
    }
}