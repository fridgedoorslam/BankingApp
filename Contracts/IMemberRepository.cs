using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMemberRepository : IRepositoryBase<Member>
    {
        IEnumerable<Member> GetAllMembers();
    }
}