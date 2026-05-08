using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;
using PayBridge.Features.Contracts;
using PayBridge.Features.Payments.Models;

namespace PayBridge.Features.Users;

// to model the supabase user table
public class SupabaseUser
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public UserProfile Profile { get; set; } = default!;
}
public class UserProfile
{
    public Guid UserId { get; set; }
    public string FullName { get; set; } = default!;
    public string Phone { get; set; } = default!;

    public string? GhanaCardIdNumber { get; set; }
    public string? GhanaCardIdFront { get; set; }
    public string? GhanaCardIdBack { get; set; }
    public string KycStatus { get; set; } = "pending";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<PaymentAccount>? PaymentAccounts { get; set; }
    public List<Contract> UserContracts { get; set; } = new();

    public List<Contract> ClientContracts { get; set; } = new();

}

