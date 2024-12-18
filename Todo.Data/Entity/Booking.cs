using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Data.Entity
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

        [Required]
        public Performance Performance { get; set; }
    }
}

