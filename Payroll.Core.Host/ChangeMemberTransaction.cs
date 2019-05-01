using Payroll.Core.Domain;

namespace Payroll.Core.Host
{
    public class ChangeMemberTransaction : ChangeAffiliationTransaction
    {
        private int _memberId;
        private double _dues;

        public ChangeMemberTransaction(
            int employeeId, int memberId, double dues) : base(employeeId)
        {
            _memberId = memberId;
            _dues = dues;
        }

        public override Affiliation Affiliation 
        {
            get
            {
                return new UnionAffiliation(_memberId, _dues);
            }
        }

        public override void RecordMemberShip(Employee employee)
        {
            PayrollRepository.AddUnionMember(_memberId, employee);
        }
    }
}