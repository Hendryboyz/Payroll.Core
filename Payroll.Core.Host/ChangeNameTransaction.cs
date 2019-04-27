namespace Payroll.Core.Host
{
    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private string _newName;

        public ChangeNameTransaction(int employeeId, string name) : base(employeeId)
        {
            _newName = name;
        }

        protected override void Change(Employee employee)
        {
            employee.Name = _newName;
        }
    }
}