namespace Payroll.Core.Host
{
    public class HoldMethod : PaymentMethod
    {
        public override void Pay(PayCheck payCheck)
        {
            payCheck.SetField("Disposition", "Hold");
        }
    }
}