using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.Domain;
using Payroll.Core.Classifications;
using Payroll.Core.Transactions;
using Payroll.Core.DataBase;
using Payroll.Core.Schedules;
using Payroll.Core.Methods;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class AddEmployeeTests
    {
        [Test]
        public void TestAddSalariedEmployee()
        {
            #region Arrange
            int empId = 1;
            string userName = "user";
            AddSalariedEmployee t = new AddSalariedEmployee(empId, userName, "Xindian", 1000.0);
            #endregion

            #region Action
            t.Execute();
            #endregion

            #region Assert
            Employee e = PayrollRepository.GetEmployee(empId);
            e.Name.Should().Be(userName);

            PaymentClassification pc = e.Classification;
            pc.Should().BeOfType<SalariedClassification>();
            SalariedClassification sc = pc as SalariedClassification;
            sc.Salary.Should().Be(1000.00);

            PaymentSchedule ps = e.Schedule;
            ps.Should().BeOfType<MonthlySchedule>();

            PaymentMethod pm = e.Method;
            pm.Should().BeOfType<HoldMethod>();
            #endregion
        }

        [Test]
        public void TestAddHourlyEmployee()
        {
            #region Arrange
            int empId = 2;
            string userName = "user";
            string address = "Xindian";
            AddHourlyEmployee t = new AddHourlyEmployee(empId, userName, address, 97.5);
            #endregion

            #region Action
            t.Execute();
            #endregion

            #region Assert
            Employee e = PayrollRepository.GetEmployee(empId);
            e.Name.Should().Be(userName);
            e.Address.Should().Be(address);

            PaymentClassification pc = e.Classification;
            pc.Should().BeOfType<HourlyClassification>();
            HourlyClassification hc = pc as HourlyClassification;
            hc.HourlyRate.Should().Be(97.5);

            PaymentSchedule ps = e.Schedule;
            ps.Should().BeOfType<WeeklySchedule>();

            PaymentMethod pm = e.Method;
            pm.Should().BeOfType<HoldMethod>();
            #endregion
        }

        [Test]
        public void TestAddCommissionedEmployee()
        {
            #region Arrange
            int empId = 3;
            string userName = "user";
            string address = "Xindian";
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, userName, address, 500.0, 97.5);
            #endregion

            #region Action
            t.Execute();
            #endregion

            #region Assert
            Employee e = PayrollRepository.GetEmployee(empId);
            e.Name.Should().Be(userName);
            e.Address.Should().Be(address);

            PaymentClassification pc = e.Classification;
            pc.Should().BeOfType<CommissionedClassification>();
            CommissionedClassification cc = pc as CommissionedClassification;
            cc.Salary.Should().Be(500.0);
            cc.CommissionedRate.Should().Be(97.5);

            PaymentSchedule ps = e.Schedule;
            ps.Should().BeOfType<BiweeklySchedule>();

            PaymentMethod pm = e.Method;
            pm.Should().BeOfType<HoldMethod>();
            #endregion
        }
    }
}