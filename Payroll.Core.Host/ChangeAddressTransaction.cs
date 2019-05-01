using Payroll.Core.Domain;

namespace Payroll.Core.Host
{
    public class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private string _newAddress;

        public ChangeAddressTransaction(int employeeId, string address) : base(employeeId)
        {
            _newAddress = address;
        }

        protected override void Change(Employee employee)
        {
            employee.Address = _newAddress;
        }
    }
}