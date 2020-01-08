using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IShareRepository : IRepositoryBase<Share>
    {
        //IEnumerable<Share> GetAllShares();

        Share GetShareByUniqueId(Guid id);

        void CreateShare(Share share);

        //void UpdateShare(Share share);

        //void DeleteShare(Share share);
    }
}