namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IMemberRepository Member { get; }

        void Save();
    }
}