using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IAccountRepository _account;
        private IShareRepository _share;

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
            }
        }

        public IShareRepository Share
        {
            get
            {
                if (_share == null)
                {
                    _share = new ShareRepository(_repoContext);
                }

                return _share;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
