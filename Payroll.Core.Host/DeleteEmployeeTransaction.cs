using Payroll.Core.Domain;

namespace Payroll.Core.Host
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