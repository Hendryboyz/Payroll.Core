using System;
using System.Collections;

namespace Payroll.Core.Host
{
    public class UnionAffliation
    {
        private Hashtable _serviceCharge;

        public UnionAffliation()
        {
            _serviceCharge = new Hashtable();    
        }

        public ServiceCharge GetServiceCharge(DateTime dateTime)
        {
            return _serviceCharge[dateTime] as ServiceCharge;
        }

        public void AddServiceCharge(ServiceCharge sc)
        {
            _serviceCharge.Add(sc.Date, sc);
        }
    }
}