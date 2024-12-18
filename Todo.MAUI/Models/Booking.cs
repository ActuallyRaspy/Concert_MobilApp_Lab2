using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.MAUI.Models
{
    public class Booking
    {
        [Key]
        public required string ID { get; set; }

        [Required]
        [StringLength(25)]
        public required string Name { get; set; }

        [Required]
        [StringLength(500)]
        public required string Email { get; set; }

        [Required]
        [ForeignKey(nameof(Performance.ID))]
        public required string PerformanceID { get; set; }
    }
}
