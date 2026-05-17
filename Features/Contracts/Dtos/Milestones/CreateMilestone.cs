using System.ComponentModel.DataAnnotations;

namespace PayBridge.Features.Contracts.Dtos.Milestones;

public class CreateMilestone
{
    [Required]
    [StringLength(250)]
    public string Description { get; set; } = default!;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public decimal Amount { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Order { get; set; }
}


