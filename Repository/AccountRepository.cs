using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return FindAll().ToList();
        }

        public Account GetAccountById(int accountId)
        {
            return FindByCondition(owner => owner.AccountId.Equals(accountId))
                    .FirstOrDefault();
        }

        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public void UpdateAccount(Account account)
        {
            Update(account);
        }

        public void DeleteAccount(Account account)
        {
            Delete(account);
        }
    }
}