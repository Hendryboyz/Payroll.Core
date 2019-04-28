using System;

namespace Payroll.Core.Host
{
    public abstract class Affiliation
    {
        public abstract double CalculateDeductions(PayCheck payCheck);
    }
}