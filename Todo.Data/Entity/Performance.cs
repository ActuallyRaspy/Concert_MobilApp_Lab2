using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Data.Entity
{
    public class Performance
    {
        [Key]
        public required string ID { get; set; }

        [Required]
        public required DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public required string Location { get; set; }

        [Required]
        [ForeignKey(nameof(Concert.ID))]
        public required string ConcertID { get; set; }

        [Required]
        public Concert Concert { get; set; }
    }
}