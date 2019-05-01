using Payroll.Core.Domain;

namespace Payroll.Core.Transactions
{
    public abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction
    {
        public ChangeAffiliationTransaction(int employeeId) : base(employeeId)
        {
            
        }

        protected override void Change(Employee employee)
        {
            RecordMemberShip(employee);
            employee.Affiliation = Affiliation;
        }

        public abstract void RecordMemberShip(Employee employee);

        public abstract Affiliation Affiliation { get; }
    }
}