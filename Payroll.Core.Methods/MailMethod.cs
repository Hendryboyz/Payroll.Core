using Payroll.Core.Domain;

namespace Payroll.Core.Methods
{
    public class MailMethod : PaymentMethod
    {
        public string Address { get; set; }

        public MailMethod(string address)
        {
            Address = address;
        }

        public override void Pay(PayCheck payCheck)
        {
            throw new System.NotImplementedException();
        }
    }
}