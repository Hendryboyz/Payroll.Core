using System;
using System.Collections;
using Payroll.Core.Domain;

namespace Payroll.Core.Classifications
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

        public void AddSalesReceipt(int employeeId, DateTime workingDate, int amount)
        {
            SalesReceipt sr = new SalesReceipt(employeeId, workingDate, amount);
            _salesReceipts.Add(sr.WorkingDate, sr);
        }

        public override double CalculatePay(PayCheck payCheck)
        {
            double totalPay = Salary;
            return totalPay;
        }
    }
}