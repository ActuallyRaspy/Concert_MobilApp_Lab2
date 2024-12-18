using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.MAUI.Models
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
        public required ICollection<Booking> Bookings { get; set; }

        [Required]
        [ForeignKey(nameof(Concert.ID))]
        public required string ConcertID { get; set; }
    }
}
