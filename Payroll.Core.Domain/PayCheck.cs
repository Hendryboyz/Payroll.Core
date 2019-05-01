using System;
using System.Collections;

namespace Payroll.Core.Domain
{
    public class PayCheck
    {
        private Hashtable _payCheckDetails;

        public DateTime PayDate { get; set; }
        public double GrossPay { get; set; }
        public double Deductions { get; set; }
        public double NetPay { get; set; }

        public PayCheck(DateTime payDate)
        {
            PayDate = payDate;
            _payCheckDetails = new Hashtable();
        }

        public void SetField(string fieldName, string fieldVal)
        {
            _payCheckDetails.Add(fieldName, fieldVal);
        }

        public string GetField(string fieldName)
        {
            return _payCheckDetails[fieldName] as string;
        }
    }
}