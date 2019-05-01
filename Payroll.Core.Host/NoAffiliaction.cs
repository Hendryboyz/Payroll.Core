using Payroll.Core.Domain;

namespace Payroll.Core.Host
{
    public class NoAffiliaction : Affiliation
    {
        public override double CalculateDeductions(PayCheck payCheck)
        {
            return 0.0;
        }
    }
}