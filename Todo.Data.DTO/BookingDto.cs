using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Todo.Data.DTO;

public class BookingDto
{
    [Required]
    [ReadOnly(true)]
    public required string ID { get; init; } // Init for Read-only

    [Required]
    [StringLength(25)]
    public required string Name { get; set; }

    [Required]
    [StringLength(500)]
    public required string Email { get; set; }

    [Required]
    public required string PerformanceID { get; set; }

    public PerformanceDto? Performance { get; set; }
}