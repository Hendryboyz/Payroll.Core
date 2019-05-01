namespace Payroll.Core.Domain
{
    public interface ITransaction
    {
        void Execute();
    }
}