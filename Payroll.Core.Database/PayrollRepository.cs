using System;
using System.Collections;
using Payroll.Core.Domain;

namespace Payroll.Core.DataBase
{
    public class PayrollRepository
    {
        private static Hashtable employees = new Hashtable();
        private static Hashtable unionMembers = new Hashtable();

        public static void Init()
        {
            employees = new Hashtable();
            unionMembers = new Hashtable();
        }

        public static void AddEmpoyee(int employId, Employee e) 
        {
            employees.Add(employId, e);
        }

        

        public static ArrayList GetAllEmployeeIds()
        {
            return new ArrayList(employees.Keys);
        }

        public static Employee GetEmployee(int employId)
        {
            return employees[employId] as Employee;
        }

        public static void DeleteEmployee(int employeeId)
        {
            employees.Remove(employeeId);
        }

        public static void RemoveUnionMember(int memberId)
        {
            unionMembers.Remove(memberId);
        }

        public static void AddUnionMember(int memberId, Employee e)
        {
            unionMembers.Add(memberId, e);
        }

        public static Employee GetUnionMember(int memberId)
        {
            return unionMembers[memberId] as Employee;
        }
    }
}