using System;

namespace Payroll.Core.Domain
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

        public bool IsPayday(DateTime _payDate)
        {
            return Schedule.IsPayDay(_payDate);
        }

        public void Payday(PayCheck payCheck)
        {
            payCheck.GrossPay = Classification.CalculatePay(payCheck);
            payCheck.Deductions = Affiliation.CalculateDeductions(payCheck);
            payCheck.NetPay = payCheck.GrossPay - payCheck.Deductions;
            Method.Pay(payCheck);
        }
    }
}