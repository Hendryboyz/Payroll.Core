using System;
using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.Host;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class ChangeNameTransactionTests
    {
        [Test]
        public void TestChangeNameTransaction()
        {
            int employeeId = 10;
            AddEmployTransaction t = new AddHourlyEmployee(employeeId, "Bill", "Home", 15.25);
            t.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Name.Should().Be("Bill");
            ChangeNameTransaction cnt = new ChangeNameTransaction(employeeId, "Bob");

            cnt.Execute();

            e = PayrollRepository.GetEmployee(employeeId);
            e.Name.Should().Be("Bob");
        }

        [Test]
        public void GivenNotExistingEmployeeToChangeEmployeeTransaction_WhenExecute_ThenThrowInvalidOperationException()
        {
            int employeeId = 1000;

            ChangeEmployeeTransaction cnt = new ChangeNameTransaction(employeeId, "Bob");

            Exception ex = Assert.Catch<InvalidOperationException>(() => cnt.Execute());

            ex.Message.Should().Contain("No such employee.");
        }
    }
}