using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public class Member : DbContext
    {
        public int MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
