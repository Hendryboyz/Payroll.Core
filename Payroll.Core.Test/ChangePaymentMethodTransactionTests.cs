using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.Host;
using Payroll.Core.Domain;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class ChangePaymentMethodTransactionTransactionTests
    {
        [Test]
        public void TestChangeMailMethodTransaction()
        {
            int employeeId = 15;
            AddEmployTransaction aet = new AddSalariedEmployee(employeeId, "Bob", "Home", 1000.0);
            aet.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Method.Should().BeOfType<HoldMethod>();
            ChangeMailMethodTransation cmmt = new ChangeMailMethodTransation(employeeId, "home");

            cmmt.Execute();

            e = PayrollRepository.GetEmployee(employeeId);
            e.Method.Should().BeOfType<MailMethod>();
            MailMethod mm = e.Method as MailMethod;
            mm.Address.Should().Be("home");
        }

        [Test]
        public void TestChangeDirectMethodTransaction()
        {
            int employeeId = 16;
            AddEmployTransaction aet = new AddSalariedEmployee(employeeId, "Bob", "Home", 1000.0);
            aet.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Method.Should().BeOfType<HoldMethod>();
            ChangeDirectMethodTransaction cdmt = new ChangeDirectMethodTransaction(employeeId, "ctbc", "1234");

            cdmt.Execute();

            e = PayrollRepository.GetEmployee(employeeId);
            e.Method.Should().BeOfType<DirectMethod>();
            DirectMethod dm = e.Method as DirectMethod;
            dm.Bank.Should().Be("ctbc");
            dm.Account.Should().Be("1234");
        }


        [Test]
        public void TestChangeHoldMethodTransaction()
        {
            int employeeId = 17;
            AddEmployTransaction aet = new AddSalariedEmployee(employeeId, "Bob", "Home", 1000.0);
            aet.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            ChangeDirectMethodTransaction cdmt = new ChangeDirectMethodTransaction(employeeId, "ctbc", "1234");
            cdmt.Execute();
            e.Method.Should().BeOfType<DirectMethod>();
            ChangeHoldMethodTransaction chmt = new ChangeHoldMethodTransaction(employeeId);

            chmt.Execute();

            e = PayrollRepository.GetEmployee(employeeId);
            e.Method.Should().BeOfType<HoldMethod>();
        }
    }
}