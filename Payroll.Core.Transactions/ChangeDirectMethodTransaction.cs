using Payroll.Core.Domain;

namespace Payroll.Core.Transactions
{
    public class ChangeDirectMethodTransaction : ChangePaymentMethodTransaction
    {
        private string _bank;
        private string _account;

        public ChangeDirectMethodTransaction(
            int employeeId, string bank, string account) : base(employeeId)
        {
            _bank = bank;
            _account = account;
        }

        public override PaymentMethod PaymentMethod
        {
            get
            {
                return new DirectMethod(_bank, _account);
            }
        }
    }
}