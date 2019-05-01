using Payroll.Core.Domain;
using Payroll.Core.Classifications;

namespace Payroll.Core.Transactions
{
    public class AddCommissionedEmployee : AddEmployTransaction
    {
        private readonly double _salary;
        private readonly double _commissionedRate;

        public AddCommissionedEmployee(
            int employeeId, 
            string name, 
            string address, 
            double salary,
            double commissionedRate) : base (employeeId, name, address)
        {
            _salary = salary;
            _commissionedRate = commissionedRate;    
        }

        protected override PaymentClassification CreatePaymentClassification()
        {
            return new CommissionedClassification(_salary, _commissionedRate);
        }

        protected override PaymentSchedule CreatePaymentSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}