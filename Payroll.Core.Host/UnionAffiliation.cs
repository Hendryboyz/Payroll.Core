using System;
using System.Collections;

namespace Payroll.Core.Host
{
    public class UnionAffiliation : Affiliation
    {
        public int MemberId { get; set; }
        public double Dues { get; set; }
        
        private Hashtable _serviceCharge;

        public UnionAffiliation()
        {
            _serviceCharge = new Hashtable();
        }
        
        public UnionAffiliation(int memberId, double dues) : this()
        {
            MemberId = memberId;
            Dues = dues;
        }

        public ServiceCharge GetServiceCharge(DateTime dateTime)
        {
            return _serviceCharge[dateTime] as ServiceCharge;
        }

        public void AddServiceCharge(ServiceCharge sc)
        {
            _serviceCharge.Add(sc.Date, sc);
        }

        public override double CalculateDeductions(PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}