using Payroll.Core.Domain;

namespace Payroll.Core.Transactions
{
    public class ChangeUnaffiliatedTransaction : ChangeAffiliationTransaction
    {
        public ChangeUnaffiliatedTransaction(int employeeId) : base(employeeId)
        {
        }

        public override Affiliation Affiliation
        {
            get
            {
                return new NoAffiliaction();
            }
        }

        public override void RecordMemberShip(Employee employee)
        {
            UnionAffiliation ua = employee.Affiliation as UnionAffiliation;
            if (ua != null) {
                int memberId = ua.MemberId;
                PayrollRepository.RemoveUnionMember(memberId);
            }
        }
    }
}