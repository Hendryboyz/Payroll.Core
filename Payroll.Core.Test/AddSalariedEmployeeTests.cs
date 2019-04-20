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
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "user", "Xindian", 1000.0);
            #endregion

            #region Action
            t.Execute();
            #endregion

            #region Assert
            Employee e = PayrollRepository.GetEmployee(empId);
            e.Name.Should().Be("user");

            PaymentClassification pc = e.Classification;
            pc.Should().BeOfType<SalariedClassification>();
            SalariedClassification sc = pc as SalariedClassification;
            sc.Salary.Should().Be(1000.00);

            PaymentSchedule ps = e.Schedule;
            ps.Should().BeOfType<MonthlySchedule>();

            PaymentMethod pm = e.Method;
            ps.Should().BeOfType<HoldMethod>();
            #endregion
        }
    }
}