using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.Host;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class AddSalariedEmployeeTests
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
    }
}