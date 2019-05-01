using System;
using System.Collections;
using Payroll.Core.Domain;

namespace Payroll.Core.Host
{
    public class PaydayTransaction : ITransaction
    {
        private DateTime _payDate;
        private Hashtable _payChecks;

        public PaydayTransaction(DateTime payDate)
        {
            _payDate = payDate;
            _payChecks = new Hashtable();
        }

        public void Execute()
        {
            ArrayList employeeIds = PayrollRepository.GetAllEmployeeIds();
            foreach (int eachId in employeeIds)
            {
                Employee e = PayrollRepository.GetEmployee(eachId);
                if (e.IsPayday(_payDate))
                {
                    PayCheck pc = new PayCheck(_payDate);
                    _payChecks[eachId] = pc;
                    e.Payday(pc);
                    pc.PayDate = _payDate;
                }
            }
        }

        public PayCheck GetPayCheck(int employeeId)
        {
            return  _payChecks[employeeId] as PayCheck;
        }
    }
}