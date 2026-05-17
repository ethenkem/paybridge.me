using PayBridge.Features.Users;

namespace PayBridge.Features.Payments.Models;

public enum ContractStatus
{
    Active,
    Cancelled
}

public class PaymentAccount
{
    public Guid Id { get; set; }

    public Guid userId { get; set; }

    public UserProfile UserProfile { get; set; } = default!;

    public string BankName { get; set; } = default!;

    public string BankCode { get; set; } = default!;

    public string AccountName { get; set; } = default!;

    public string AccountNumber { get; set; } = default!;

    public decimal AccountBalance { get; set; } = default!;

    public bool IsActive { get; set; } = true;

}