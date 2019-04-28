namespace Payroll.Core.Host
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public PaymentClassification Classification { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public Affiliation Affiliation { get; set; }
    }
}