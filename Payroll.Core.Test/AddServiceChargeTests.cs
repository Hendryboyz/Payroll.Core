using System;
using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.Host;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class AddServiceChargeTests
    {
        [Test]
        public void TestAddServiceCharge() {
            #region Arrange
            int employeeId = 9;
            AddSalariedEmployee asd = new AddSalariedEmployee(employeeId, "user", "home", 1000.0);
            asd.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Should().NotBeNull();

            UnionAffliation af = new UnionAffliation();
            e.Affliation = af;
            int memberId = 886;
            PayrollRepository.AddUnionMember(memberId, e);

            ServiceChargeTransaction sct = new ServiceChargeTransaction(
                memberId, new DateTime(2019, 10, 10), 10.0);
            #endregion

            #region Action
            sct.Execute();
            #endregion

            #region Assert
            ServiceCharge sc = af.GetServiceCharge(new DateTime(2019, 10, 10));
            sc.Should().NotBeNull();
            sc.Date.Should().Be(new DateTime(2019, 10, 10));
            sc.Amount.Should().Be(10.0);
            #endregion
        }
    }
}