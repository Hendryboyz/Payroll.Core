using Payroll.Core.Domain;

namespace Payroll.Core.Classifications
{
    public class SalariedClassification : PaymentClassification
    {
        public SalariedClassification(double salary)
        {
            Salary = salary;
        }

        public double Salary { get; set; }

        public override double CalculatePay(PayCheck payCheck)
        {
            return Salary;
        }
    }
}