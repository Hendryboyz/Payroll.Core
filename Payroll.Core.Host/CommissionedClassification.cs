namespace Payroll.Core.Host
{
    public class CommissionedClassification : PaymentClassification
    {
        public double Salary { get; set; }
        public double CommissionedRate { get; set; }

        public CommissionedClassification(double salary, double commissionedRate)
        {
            Salary = salary;
            CommissionedRate = commissionedRate;
        }
    }
}