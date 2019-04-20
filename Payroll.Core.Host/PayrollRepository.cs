using System.Collections;

namespace Payroll.Core.Host
{
    public class PayrollRepository
    {
        private static Hashtable employees = new Hashtable();

        public static void AddEmpoyee(int employId, Employee e) 
        {
            employees.Add(employId, e);
        }


        public static Employee GetEmployee(int employId)
        {
            return employees[employId] as Employee;
        }
    }
}