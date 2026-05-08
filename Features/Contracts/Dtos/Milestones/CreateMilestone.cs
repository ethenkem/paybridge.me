namespace PayBridge.Features.Contracts.Dtos.Milestones;

public class CreateMilestone
{
    public string Description { get; set; } = default!;
    public decimal Amount { get; set; }
    public int Order { get; set; }
}

