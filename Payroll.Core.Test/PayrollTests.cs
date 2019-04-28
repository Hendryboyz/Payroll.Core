using System;
using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.Host;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class PayrollTests
    {
        [SetUp]
        public void SetUp()
        {
            PayrollRepository.Init();
        }

        [Test]
        public void PaySingleSalariedEmployee()
        {
            int employeeId = 20;
            AddEmployTransaction aet = new AddSalariedEmployee(
                employeeId, "Bob", "Home", 1000.0
            );
            aet.Execute();
            DateTime payDate = new DateTime(2019, 4, 30);
            PaydayTransaction pt = new PaydayTransaction(payDate);

            pt.Execute();

            PayCheck pc = pt.GetPayCheck(employeeId);
            pc.Should().NotBeNull();
            pc.PayDate.Should().Be(payDate);
            pc.GrossPay.Should().Be(1000.0);
            pc.GetField("Disposition").Should().Be("Hold");
            pc.Deductions.Should().Be(0.0);
            pc.NetPay.Should().Be(1000.0);
        }

        [Test]
        public void PaySingleSalariedEmployeeOnWrongDate()
        {
            int employeeId = 21;
            AddEmployTransaction aet = new AddSalariedEmployee(
                employeeId, "Bob", "Home", 1000.0
            );
            aet.Execute();
            DateTime payDate = new DateTime(2019, 4, 28);
            PaydayTransaction pt = new PaydayTransaction(payDate);

            pt.Execute();

            PayCheck pc = pt.GetPayCheck(employeeId);
            pc.Should().BeNull();
        }
    }
}