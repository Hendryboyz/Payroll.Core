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
            _employee.Address = address;
        }

        public void Execute()
        {
            _employee.Classification = CreatePaymentClassification();
            _employee.Schedule = CreatePaymentSchedule();
            _employee.Method = new HoldMethod();
            _employee.Affiliation = new NoAffiliaction();
                        
            PayrollRepository.AddEmpoyee(_employee.Id, _employee);
        }

        protected abstract PaymentClassification CreatePaymentClassification();
        protected abstract PaymentSchedule CreatePaymentSchedule();
    }
}