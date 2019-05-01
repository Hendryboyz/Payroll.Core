using System;
using FluentAssertions;
using NUnit.Framework;
using Payroll.Core.DataBase;
using Payroll.Core.Domain;
using Payroll.Core.Classifications;
using Payroll.Core.Transactions;

namespace Payroll.Core.Test
{
    [TestFixture]
    public class SalesReceiptTransactionTests
    {
        [Test]
        public void TestAddSalesReceiptTransaction()
        {
            #region Arrange
            int employeeId = 5;
            AddCommissionedEmployee t = new AddCommissionedEmployee(employeeId, "user", "home", 1000, 97.5);
            t.Execute();

            DateTime workingDate = new DateTime(2019, 4, 21);
            SalesReceiptTransaction srt = new SalesReceiptTransaction(
                employeeId, workingDate, 200
            );
            #endregion

            #region Action
            srt.Execute();
            #endregion

            #region Assert
            Employee e = PayrollRepository.GetEmployee(employeeId);
            e.Should().NotBeNull();

            e.Classification.Should().BeOfType<CommissionedClassification>();
            CommissionedClassification cc = e.Classification as CommissionedClassification;

            SalesReceipt sr = cc.GetSalesReceipt(workingDate);
            sr.Should().NotBeNull();
            sr.Amount.Should().Be(200);
            #endregion
        }

        [Test]
        public void GivenNotExistingEmployeeId_WhenExecuteAddSalesReceiptTransaction_ThenThrowInvalidOperationException()
        {
            #region Arrange
            int employeeId = 1000;
            DateTime workingDate = new DateTime(2019, 4, 21);
            SalesReceiptTransaction srt = new SalesReceiptTransaction(
                employeeId, workingDate, 200
            );
            #endregion

            #region Action
            Exception ex = Assert.Catch<Exception>(() => srt.Execute());
            #endregion

            #region Assert
            ex.Should().BeOfType<InvalidOperationException>();
            ex.Message.Should().Contain("No such employee.");
            #endregion
        }

        [Test]
        public void GivenNotCommenssionedEmployee_WhenExecuteAddSalesReceiptTransaction_ThenThrowInvalidOperationException()
        {
            #region Arrange
            int employeeId = 8;
            AddSalariedEmployee t = new AddSalariedEmployee(employeeId, "user", "home", 1000);
            t.Execute();

            DateTime workingDate = new DateTime(2019, 4, 21);
            SalesReceiptTransaction srt = new SalesReceiptTransaction(
                employeeId, workingDate, 200
            );
            #endregion

            #region Action
            Exception ex = Assert.Catch<Exception>(() => srt.Execute());
            #endregion

            #region Assert
            ex.Should().BeOfType<InvalidOperationException>();
            ex.Message.Should().Contain("non-commenssioned employee");
            #endregion
        }
    }
}