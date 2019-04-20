namespace Payroll.Core.Host
{
    public class AddSalariedEmployee : ITransaction
    {
        public AddSalariedEmployee(int employeeId, string name, string address, double salaries)
        {
            
        }

        public void Execute()
        {
        }
    }
}