using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.DataBase;
using Payroll.Core.Affiliations;
using Payroll.Core.Domain;
using Payroll.Core.Transactions;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class ChangeAffliationTransactionTests
    {
        [Test]
        public void ChangeUnionMember() {
            int employeeId = 18;
            AddEmployTransaction aet = new AddHourlyEmployee(employeeId, "Bill", "home", 19.1);
            aet.Execute();

            int memberId = 8591;
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(employeeId, memberId, 99.42);

            cmt.Execute();

            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Should().NotBeNull();
            e.Affiliation.Should().NotBeNull();
            e.Affiliation.Should().BeOfType<UnionAffiliation>();

            UnionAffiliation uf = e.Affiliation as UnionAffiliation;
            uf.Dues.Should().Be(99.42);
            Employee member = PayrollRepository.GetUnionMember(memberId);
            member.Should().NotBeNull();
            member.Should().Be(e);
        }


        [Test]
        public void ChangeUnaffiliatedTransaction()
        {
            int employeeId = 19;
            AddEmployTransaction aet = new AddHourlyEmployee(employeeId, "Bill", "home", 19.1);
            aet.Execute();
            int memberId = 8592;
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(employeeId, memberId, 99.42);
            cmt.Execute();
            Employee um = PayrollRepository.GetUnionMember(memberId);
            um.Should().NotBeNull();
            ChangeUnaffiliatedTransaction cut = new ChangeUnaffiliatedTransaction(employeeId);

            cut.Execute();

            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Should().NotBeNull();
            e.Affiliation.Should().NotBeNull();
            e.Affiliation.Should().BeOfType<NoAffiliaction>();

            Employee member = PayrollRepository.GetUnionMember(memberId);
            member.Should().BeNull();
        }
    }
}