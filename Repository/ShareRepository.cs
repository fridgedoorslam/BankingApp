using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ShareRepository : RepositoryBase<Share>, IShareRepository
    {
        public ShareRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Share GetShareByUniqueId(Guid id)
        {
            return FindByCondition(share => share.UniqueId.Equals(id)).FirstOrDefault();
        }

        public void CreateShare(Share share)
        {
            Create(share);
        }
    }
}
