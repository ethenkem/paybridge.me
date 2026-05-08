using System.ComponentModel.DataAnnotations;

namespace PayBridge.Features.Contracts.Dtos.Contracts;

public class CreateContractDto
{
    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Tile length should be between 2 and 20")]
    public string Title { get; set; } = default!;

    [Required]
    public string Description { get; set; } = default!;

}
