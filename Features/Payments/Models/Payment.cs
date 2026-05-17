
namespace PayBridge.Features.Payments.Models;

public enum PaymentStatus
{
    Pending,
    Released,
    Refunded,
    Failed
}

public class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ReleasedAt { get; set; }
    
    public string? Reference { get; set; }
    public string? Metadata { get; set; }
}