using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.Host;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class ChangeAddressTransactionTests
    {
        [Test]
        public void TestChangeAddressTransaction()
        {
            int employeeId = 11;
            AddEmployTransaction t = new AddHourlyEmployee(employeeId, "Bill", "Home", 15.25);
            t.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Address.Should().Be("Home");
            ChangeAddressTransaction cat = new ChangeAddressTransaction(employeeId, "Company");

            cat.Execute();

            e = PayrollRepository.GetEmployee(employeeId);
            e.Address.Should().Be("Company");
        }
    }
}