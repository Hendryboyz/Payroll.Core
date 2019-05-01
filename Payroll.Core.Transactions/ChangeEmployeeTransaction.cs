using System;
using Payroll.Core.Domain;
using Payroll.Core.DataBase;
namespace Payroll.Core.Transactions
{
    public abstract class ChangeEmployeeTransaction : ITransaction
    {
        private int _employeeId;

        public ChangeEmployeeTransaction(int employeeId)
        {
            _employeeId = employeeId;
        }

        public void Execute()
        {
            Employee e = PayrollRepository.GetEmployee(_employeeId);
            if (e != null) {
                Change(e);
            }
            else {
                throw new InvalidOperationException("No such employee.");
            }
        }

        protected abstract void Change(Employee employee);
    }
}