using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Share> Shares { get; set; }
    }
}
