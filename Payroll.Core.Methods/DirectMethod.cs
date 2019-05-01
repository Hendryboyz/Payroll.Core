using Payroll.Core.Domain;

namespace Payroll.Core.Methods
{
    public class DirectMethod : PaymentMethod
    {
        public string Bank { get; set; }
        public string Account { get; set; }

        public DirectMethod(string bank, string account)
        {
            Bank = bank;
            Account = account;
        }

        public override void Pay(PayCheck payCheck)
        {
            throw new System.NotImplementedException();
        }
    }
}