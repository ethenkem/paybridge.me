
using System.ComponentModel.DataAnnotations.Schema;
using PayBridge.Features.Users;

namespace PayBridge.Features.Contracts;

public enum ContractStatus
{
    Draft,
    AwaitingSigning,
    AwaitingDeposit,
    Active,
    Completed,
    Disputed,
    Cancelled
}
public class Contract
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public UserProfile UserProfile { get; set; } = default!;
    public Guid? ClientId { get; set; }
    public UserProfile? ClientProfile { get; set; }
    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public ContractStatus Status { get; set; } = ContractStatus.Draft;
    public string LinkToken { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Milestone> Milestones { get; set; } = new();
}
