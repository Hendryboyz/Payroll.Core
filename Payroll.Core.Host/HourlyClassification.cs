namespace Payroll.Core.Host
{
    public class HourlyClassification : PaymentClassification
    {
        public double HourlyRate { get; set; }

        public HourlyClassification(double hourlyRate)
        {
            HourlyRate = hourlyRate;
        }
    }
}