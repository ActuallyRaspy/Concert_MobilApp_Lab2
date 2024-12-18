using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.DTO;

namespace Todo.MAUI.Models
{
    public class Concert
    {
        [Required]
        [ReadOnly(true)]
        public required string ID { get; init; } // Init for Read-only

        [Required]
        [StringLength(50)]
        public required string Title { get; set; }

        [Required]
        [StringLength(500)]
        public required string Description { get; set; }

        public ICollection<PerformanceDto>? Performances { get; set; } = new List<PerformanceDto>();

    }
}
