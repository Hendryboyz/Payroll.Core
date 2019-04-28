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

        [Test]
        public void PayingSingleHourlyEmployeeWithouTTimeCards()
        {
            int employeeId = AddHourlyEmployee();
            DateTime payDate = new DateTime(2019, 4, 26);
            PaydayTransaction pt = new PaydayTransaction(payDate);

            pt.Execute();

            PayCheck pc = pt.GetPayCheck(employeeId);
            ValidateHourlyPayCheck(payDate, pc, 0.0);
        }

        private int AddHourlyEmployee()
        {
            int employeeId = 1;
            AddEmployTransaction t = new AddHourlyEmployee(
                employeeId, "Bob", "Home", 19.25
            );
            t.Execute();
            return employeeId;
        }

        private void ValidateHourlyPayCheck(DateTime payDate, PayCheck payCheck, double expectedPay)
        {
            payCheck.Should().NotBeNull();
            payCheck.PayDate.Should().Be(payDate);
            payCheck.GrossPay.Should().Be(expectedPay);
            payCheck.GetField("Disposition").Should().Be("Hold");
            payCheck.Deductions.Should().Be(0.0);
            payCheck.NetPay.Should().Be(expectedPay);
        }

        [Test]
        public void PayingSingleHourlyEmployeeWithOneTimeCard()
        {
            int employeeId = AddHourlyEmployee();
            TimeCardTransaction tct = new TimeCardTransaction(
                employeeId, new DateTime(2019, 4, 22), 2);
            tct.Execute();

            DateTime payDate = new DateTime(2019, 4, 26);
            PaydayTransaction pt = new PaydayTransaction(payDate);

            pt.Execute();

            PayCheck pc = pt.GetPayCheck(employeeId);
            ValidateHourlyPayCheck(payDate, pc, 2 * 19.25);
        }

        [Test]
        public void PayingSingleHourlyEmployeeWithOneOverTimeCard()
        {
            int employeeId = AddHourlyEmployee();
            TimeCardTransaction tct = new TimeCardTransaction(
                employeeId, new DateTime(2019, 4, 22), 9);
            tct.Execute();

            DateTime payDate = new DateTime(2019, 4, 26);
            PaydayTransaction pt = new PaydayTransaction(payDate);

            pt.Execute();

            PayCheck pc = pt.GetPayCheck(employeeId);
            ValidateHourlyPayCheck(payDate, pc, (8 + 1.5) * 19.25);
        }

        [Test]
        public void PayingSingleHourlyEmployeeOnWrongDate()
        {
            int employeeId = AddHourlyEmployee();
            TimeCardTransaction tct = new TimeCardTransaction(
                employeeId, new DateTime(2019, 4, 22), 9);
            tct.Execute();

            DateTime payDate = new DateTime(2019, 4, 25);
            PaydayTransaction pt = new PaydayTransaction(payDate);

            pt.Execute();

            PayCheck pc = pt.GetPayCheck(employeeId);
            pc.Should().BeNull();
        }

        [Test]
        public void PayingSingleHourlyEmployeeWithTwoTimeCards()
        {
            int employeeId = AddHourlyEmployee();
            AddTimeCard(employeeId, new DateTime(2019, 4, 22), 2);
            AddTimeCard(employeeId, new DateTime(2019, 4, 23), 5);

            DateTime payDate = new DateTime(2019, 4, 26);
            PaydayTransaction pt = new PaydayTransaction(payDate);

            pt.Execute();

            PayCheck pc = pt.GetPayCheck(employeeId);
            ValidateHourlyPayCheck(payDate, pc, 7 * 19.25);
        }

        private void AddTimeCard(int employeeId, DateTime workDate, double hours)
        {
            TimeCardTransaction tct = new TimeCardTransaction(employeeId, workDate, hours);
            tct.Execute();
        }


        [Test]
        public void PayingSingleHourlyEmployeeSpanningTwoPayPeriod()
        {
            int employeeId = AddHourlyEmployee();
            DateTime payDate = new DateTime(2019, 4, 26);
            DateTime previosPayDate = payDate.AddDays(-7);

            AddTimeCard(employeeId, previosPayDate, 2);
            AddTimeCard(employeeId, payDate, 5);

            PaydayTransaction pt = new PaydayTransaction(payDate);

            pt.Execute();

            PayCheck pc = pt.GetPayCheck(employeeId);
            ValidateHourlyPayCheck(payDate, pc, 5 * 19.25);
        }

        [Test]
        public void PayingSingleCommissionedEmployeeWithoutSaleReciept()
        {
            int employeeId = AddCommissionedEmployee();
            DateTime payDate = new DateTime(2019, 4, 19);

            PaydayTransaction pt = new PaydayTransaction(payDate);

            pt.Execute();

            PayCheck pc = pt.GetPayCheck(employeeId);
            ValidateHourlyPayCheck(payDate, pc, 800.0);
        }

        private int AddCommissionedEmployee()
        {
            int employeeId = 1;
            AddEmployTransaction t = new AddCommissionedEmployee(
                employeeId, "Bob", "Home", 800.0, 0.75
            );
            t.Execute();
            return employeeId;
        }
    }
}