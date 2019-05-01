using System;

namespace Payroll.Core.Domain
{
    public abstract class Affiliation
    {
        public abstract double CalculateDeductions(PayCheck payCheck);
    }
}