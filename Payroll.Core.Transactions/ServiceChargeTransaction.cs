using System;
using Payroll.Core.Domain;
using Payroll.Core.Affiliations;

namespace Payroll.Core.Transactions
{
    public class ServiceChargeTransaction : ITransaction
    {
        private int _memberId;
        private DateTime _date;
        private double _amount;

        public ServiceChargeTransaction(int memberId, DateTime date, double amount)
        {
            _memberId = memberId;
            _date = date;
            _amount = amount;
        }

        public void Execute()
        {
            Employee e = PayrollRepository.GetUnionMember(_memberId);
            bool isExistingMember = e != null;
            if (isExistingMember)
            {
                UnionAffiliation ua = e.Affiliation as UnionAffiliation;
                ServiceCharge sc = new ServiceCharge(_date, _amount);
                ua.AddServiceCharge(sc);
            }
            else
            {
                throw new InvalidOperationException("No such union member.");    
            }
        }
    }
}