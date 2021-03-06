using Payroll.Core.Domain;
using Payroll.Core.Methods;

namespace Payroll.Core.Transactions
{
    public class ChangeMailMethodTransation : ChangePaymentMethodTransaction
    {
        private string _address;

        public ChangeMailMethodTransation(int employeeId, string address) : base(employeeId)
        {
            _address = address;
        }

        public override PaymentMethod PaymentMethod 
        {
            get
            {
                return new MailMethod(_address);
            }
        }
    }
}