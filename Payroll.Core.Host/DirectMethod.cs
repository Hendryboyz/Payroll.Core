namespace Payroll.Core.Host
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
    }
}