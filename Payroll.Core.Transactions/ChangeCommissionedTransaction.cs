using Payroll.Core.Domain;
using Payroll.Core.Classifications;
using Payroll.Core.Schedules;

namespace Payroll.Core.Transactions
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private double _salary;
        private double _commissionedRate;

        public ChangeCommissionedTransaction(
            int employeeId,
            double salary,
            double commissionedRate
        ) : base(employeeId)
        {
            _salary = salary;
            _commissionedRate = commissionedRate;
        }

        protected override PaymentClassification Classification
        {
            get
            {
                return new CommissionedClassification(_salary, _commissionedRate);
            }
        }

        protected override PaymentSchedule Schedule
        {
            get
            {
                return new BiweeklySchedule();
            }
        }
    }
}