using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IMemberRepository _member;

        public IMemberRepository Member
        {
            get
            {
                if (_member == null)
                {
                    _member = new MemberRepository(_repoContext);
                }

                return _member;
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