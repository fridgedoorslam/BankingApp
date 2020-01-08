using System;

namespace Entities.DataTransferObjects
{
    public class ShareDto
    {
        public Guid UniqueId { get; set; }

        public int ShareId { get; set; }

        public DateTime? OpenDate { get; set; } = DateTime.Now;

        public DateTime? CloseDate { get; set; }

        public int AccountId { get; set; }
    }
}
