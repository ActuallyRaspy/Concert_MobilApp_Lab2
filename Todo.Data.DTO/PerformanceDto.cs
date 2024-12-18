using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Todo.Data.DTO
{
    public class PerformanceDto
    {
        [Required]
        [ReadOnly(true)]
        public required string ID { get; init; } // Init for Read-only

        [Required]
        public required DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public required string Location { get; set; }

        public required ICollection<BookingDto>? Bookings { get; set; } = new List<BookingDto>();

        [Required]
        public required string ConcertID { get; set; }

        public ConcertDto? Concert { get; set; }
    }
}
