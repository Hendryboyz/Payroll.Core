using System;
using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.Host;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class TimeCardTransactionTest
    {
        [Test]
        public void TestAddTimeCard()
        {
            #region Arrange
            int employeeId = 5;
            AddHourlyEmployee t = new AddHourlyEmployee(employeeId, "user", "home", 97.5);
            t.Execute();

            DateTime workingDay = new DateTime(2019, 4, 21);
            TimeCardTransaction tct = new TimeCardTransaction(
                employeeId, workingDay, 8.0
            );
            #endregion

            #region Action
            tct.Execute();
            #endregion

            #region Assert
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Should().NotBeNull();

            e.Classification.Should().BeOfType<HourlyClassification>();
            HourlyClassification hc = e.Classification as HourlyClassification;

            TimeCard tc = hc.GetTimeCard(workingDay);
            tc.Should().NotBeNull();
            tc.Hours.Should().Be(8.0);
            #endregion
        }

        [Test]
        public void GivenNotExistingEmployeeId_WhenExecuteTimeCardTransaction_ThenThrowInvalidOperationException()
        {
            #region Arrange
            int employeeId = 1000;

            DateTime workingDay = new DateTime(2019, 4, 21);
            TimeCardTransaction tct = new TimeCardTransaction(
                employeeId, workingDay, 8.0
            );
            #endregion

            #region Action
            Exception ex = Assert.Catch<Exception>(() => tct.Execute());
            #endregion

            #region Assert
            ex.Should().BeOfType<InvalidOperationException>();
            ex.Message.Should().Contain("No such employee");
            #endregion
        }


        [Test]
        public void GivenNotHourlyEmployee_WhenExecuteTimeCardTransaction_ThenThrowInvalidOperationException()
        {
            #region Arrange
             int employeeId = 6;
            AddSalariedEmployee t = new AddSalariedEmployee(employeeId, "user", "home", 1000.0);
            t.Execute();

            DateTime workingDay = new DateTime(2019, 4, 21);
            TimeCardTransaction tct = new TimeCardTransaction(
                employeeId, workingDay, 8.0
            );
            #endregion

            #region Action
            Exception ex = Assert.Catch<Exception>(() => tct.Execute());
            #endregion

            #region Assert
            ex.Should().BeOfType<InvalidOperationException>();
            ex.Message.Should().Contain("non-hourly employee");
            #endregion
        }
    }
}