using System;
using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.Host;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class ChangeClassificationTransactionTests
    {
        [Test]
        public void TestChangeHourlyTransaction() {
            int employeeId = 12;
            AddEmployTransaction AddHourlyEmployee = new AddSalariedEmployee(employeeId, "Bill", "Home", 1000.0);
            AddHourlyEmployee.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Classification.Should().BeOfType<SalariedClassification>();
            ChangeHourlyTransaction cht = new ChangeHourlyTransaction(employeeId, 19.25);

            cht.Execute();

            e = PayrollRepository.GetEmployee(employeeId);
            e.Classification.Should().BeOfType<HourlyClassification>();
            HourlyClassification cc = e.Classification as HourlyClassification;
            cc.HourlyRate.Should().Be(19.25);
            e.Schedule.Should().BeOfType<WeeklySchedule>();
        }

        [Test]
        public void GivenNotExistingEmployeeIdToChangeClassifcation_WhenExecute_ThenThrowInvalidOperationException() {
            int employeeId = 1000;

            ChangeHourlyTransaction cht = new ChangeHourlyTransaction(employeeId, 19.25);

            Exception ex = Assert.Catch<InvalidOperationException>(()=>cht.Execute());

            ex.Message.Should().Contain("No such employee.");
        }

        [Test]
        public void TestChangeCommissionedTransaction() {
            int employeeId = 13;
            AddEmployTransaction AddHourlyEmployee = new AddSalariedEmployee(employeeId, "Bill", "Home", 1000.0);
            AddHourlyEmployee.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Classification.Should().BeOfType<SalariedClassification>();
            ChangeCommissionedTransaction cct = new ChangeCommissionedTransaction(employeeId, 800.0, 19.25);

            cct.Execute();

            e = PayrollRepository.GetEmployee(employeeId);
            e.Classification.Should().BeOfType<CommissionedClassification>();
            CommissionedClassification cc = e.Classification as CommissionedClassification;
            cc.Salary.Should().Be(800.0);
            cc.CommissionedRate.Should().Be(19.25);
            e.Schedule.Should().BeOfType<BiweeklySchedule>();
        }

        [Test]
        public void TestChangeSalariedTransaction() {
            int employeeId = 14;
            AddEmployTransaction ahe = new AddHourlyEmployee(employeeId, "Bill", "Home", 95.0);
            ahe.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Classification.Should().BeOfType<HourlyClassification>();
            ChangeSalariedTransation cst = new ChangeSalariedTransation(employeeId, 1000.0);

            cst.Execute();

            e = PayrollRepository.GetEmployee(employeeId);
            e.Classification.Should().BeOfType<SalariedClassification>();
            SalariedClassification sc = e.Classification as SalariedClassification;
            sc.Salary.Should().Be(1000.0);
            e.Schedule.Should().BeOfType<MonthlySchedule>();
        }
    }
}