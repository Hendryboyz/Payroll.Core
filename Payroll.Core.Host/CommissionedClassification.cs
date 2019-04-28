using System;
using System.Collections;

namespace Payroll.Core.Host
{
    public class CommissionedClassification : PaymentClassification
    {
        public double Salary { get; set; }
        public double CommissionedRate { get; set; }

        private Hashtable _salesReceipts;

        public CommissionedClassification(double salary, double commissionedRate)
        {
            Salary = salary;
            CommissionedRate = commissionedRate;
            _salesReceipts = new Hashtable();
        }

        public SalesReceipt GetSalesReceipt(DateTime workingDate)
        {
            return _salesReceipts[workingDate] as SalesReceipt;
        }

        public void AddSalesReceipt(SalesReceipt sr)
        {
            _salesReceipts.Add(sr.WorkingDate, sr);
        }

        public override double CalculatePay(PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}