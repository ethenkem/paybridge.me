using PayBridge.Features.Payments.Models;

namespace PayBridge.Features.Contracts;

public enum MilestoneStatus
{
    Pending,    // not yet funded
    Funded,     // money in escrow for this milestone
    Released,   // client approved, funds sent to freelancer
    Disputed
}
public class Milestone
{
    public int Id { get; set; }

    public Guid ContractId { get; set; }
    public Contract Contract { get; set; } = default!;

    public string Description { get; set; } = default!;
    public decimal Amount { get; set; }
    public int Order { get; set; }

    public MilestoneStatus Status { get; set; }
    public DateTime? ReleasedAt { get; set; }
    public Guid? PaymentId { get; set; }
    public Payment? Payment { get; set; }
}