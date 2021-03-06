using Payroll.Core.Domain;
using Payroll.Core.DataBase;

namespace Payroll.Core.Transactions
{
    public class DeleteEmployeeTransaction : ITransaction
    {
        private readonly int _employeeId;

        public DeleteEmployeeTransaction(int employeeId)
        {
            _employeeId = employeeId;    
        }

        public void Execute()
        {
            PayrollRepository.DeleteEmployee(_employeeId);
        }
    }
}