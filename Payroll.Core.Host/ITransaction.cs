namespace Payroll.Core.Host
{
    public interface ITransaction
    {
        void Execute();
    }
}