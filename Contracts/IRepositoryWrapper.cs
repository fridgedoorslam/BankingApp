namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }

        IShareRepository Share { get; }

        void Save();
    }
}