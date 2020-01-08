using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> GetAllAccounts();

        Account GetAccountById(int accountId);

        void CreateAccount(Account account);

        void UpdateAccount(Account account);

        void DeleteAccount(Account account);
    }
}