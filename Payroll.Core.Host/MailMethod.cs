namespace Payroll.Core.Host
{
    public class MailMethod : PaymentMethod
    {
        public string Address { get; set; }

        public MailMethod(string address)
        {
            Address = address;
        }
    }
}