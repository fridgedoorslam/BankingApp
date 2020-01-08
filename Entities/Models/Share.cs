using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Share
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UniqueId { get; set; }

        [Required]
        public int ShareId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? OpenDate { get; set; } = DateTime.Now;

        public DateTime? CloseDate { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
