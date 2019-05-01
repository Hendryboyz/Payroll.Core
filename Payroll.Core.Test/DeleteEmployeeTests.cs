using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.DataBase;
using Payroll.Core.Domain;
using Payroll.Core.Transactions;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class DeleteEmployeeTests
    {
        [Test]
        public void TestDeleteEmployee()
        {
            #region Arrange
            int employeeId = 4;
            AddSalariedEmployee t = new AddSalariedEmployee(employeeId, "user", "home", 1000.0);
            t.Execute();
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Should().NotBeNull();

            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(employeeId);
            #endregion

            #region Action
            dt.Execute();
            #endregion

            #region Assert
            e = PayrollRepository.GetEmployee(employeeId);
            e.Should().BeNull();
            #endregion
        }
    }
}