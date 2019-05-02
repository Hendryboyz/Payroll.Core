using System;
using Payroll.Core.Domain;
using Payroll.Core.Classifications;
using Payroll.Core.DataBase;

namespace Payroll.Core.Transactions
{
    public class SalesReceiptTransaction : ITransaction
    {
        private readonly int _employeeId;
        private readonly DateTime _workingDate;
        private readonly int _amount;

        public SalesReceiptTransaction(int employeeId, DateTime workingDate, int amount)
        {
            _employeeId = employeeId;
            _workingDate = workingDate;
            _amount = amount;
        }

        public void Execute()
        {
            Employee e = PayrollRepository.GetEmployee(_employeeId);
            bool isValidEmployee = e != null;
            if (isValidEmployee)
            {
                CommissionedClassification cc = e.Classification as CommissionedClassification;
                bool isCommenssionedEmployee = cc != null;
                if (isCommenssionedEmployee)
                {
                    cc.AddSalesReceipt(_employeeId, _workingDate, _amount);
                }
                else
                {
                    throw new InvalidOperationException("non-commenssioned employee");
                }
            }
            else 
            {
                throw new InvalidOperationException("No such employee.");
            }
        }
    }
}