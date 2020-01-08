namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }

        void Save();
    }
}