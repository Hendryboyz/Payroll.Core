namespace Payroll.Core.Host
{
    public abstract class AddEmployTransaction : ITransaction
    {
        private Employee _employee;

        protected AddEmployTransaction(int employeeId, string name, string address)
        {
            _employee = new Employee();
            _employee.Id = employeeId;
            _employee.Name = name;
        }

        public void Execute()
        {
            _employee.Classification = GetPaymentClassification();
            _employee.Schedule = GetPaymentSchedule();
            _employee.Method = GetPaymentMethod();
            
            PayrollRepository.AddEmpoyee(_employee.Id, _employee);
        }

        protected abstract PaymentClassification GetPaymentClassification();
        protected abstract PaymentSchedule GetPaymentSchedule();
        protected abstract PaymentMethod GetPaymentMethod();
    }
}