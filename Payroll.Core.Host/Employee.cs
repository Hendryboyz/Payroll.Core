namespace Payroll.Core.Host
{
    public class Employee
    {
        public string Name { get; set; }
        public PaymentClassification Classification { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentSchedule Schedule { get; set; }
    }
}