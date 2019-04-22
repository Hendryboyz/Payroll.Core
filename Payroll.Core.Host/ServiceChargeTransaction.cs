using System;

namespace Payroll.Core.Host
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
            UnionAffliation ua = e.Affliation;
            ServiceCharge sc = new ServiceCharge(_date, _amount);
            ua.AddServiceCharge(sc);
        }
    }
}