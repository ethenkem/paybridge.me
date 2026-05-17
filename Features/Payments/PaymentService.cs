using Microsoft.EntityFrameworkCore;
using PayBridge.Features.Contracts;
using PayBridge.Features.Payments.Dtos.Accounts;
using PayBridge.Features.Payments.Models;
using PayBridge.Infrastructure.Data;

namespace PayBridge.Features.Payments;


public class PaymentService
{
    private readonly AppDbContext _db;
    public PaymentService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Payment> TriggerPayment(int milestoneId)
    {
        var milestone = await _db.Milestones
            .FirstOrDefaultAsync(m => m.Id == milestoneId);

        if (milestone == null)
            throw new Exception("Milestone not found");

        if (milestone.PaymentId != null)
            throw new Exception("Payment already triggered for this milestone");

        var payment = new Payment
        {
            Amount = milestone.Amount,
            Status = PaymentStatus.Pending
        };

        _db.Payments.Add(payment);
        milestone.PaymentId = payment.Id;
        milestone.Status = MilestoneStatus.Funded;

        await _db.SaveChangesAsync();

        return payment;
    }

    public async Task<Payment> ReleasePayment(Guid paymentId)
    {
        var payment = await _db.Payments
            .FirstOrDefaultAsync(p => p.Id == paymentId);

        if (payment == null)
            throw new Exception("Payment not found");

        if (payment.Status == PaymentStatus.Released)
            throw new Exception("Payment already released");

        var milestone = await _db.Milestones
            .FirstOrDefaultAsync(m => m.PaymentId == paymentId);

        if (milestone == null)
            throw new Exception("Milestone not found for this payment");

        payment.Status = PaymentStatus.Released;
        payment.ReleasedAt = DateTime.UtcNow;
        milestone.Status = MilestoneStatus.Released;
        milestone.ReleasedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        return payment;
    }

    // Account Management
    public async Task<List<PaymentAccount>> GetAccounts(Guid userId)
    {
        return await _db.PaymentAccounts
            .Where(a => a.userId == userId)
            .ToListAsync();
    }

    public async Task<PaymentAccount> AddAccount(Guid userId, CreateAccountDto dto)
    {
        var account = new PaymentAccount
        {
            Id = Guid.NewGuid(),
            userId = userId,
            BankName = dto.BankName,
            BankCode = dto.BankCode,
            AccountName = dto.AccountName,
            AccountNumber = dto.AccountNumber,
            AccountBalance = 0,
            IsActive = true
        };

        _db.PaymentAccounts.Add(account);
        await _db.SaveChangesAsync();

        return account;
    }

    public async Task<PaymentAccount> UpdateAccount(Guid accountId, UpdateAccountDto dto)
    {
        var account = await _db.PaymentAccounts.FirstOrDefaultAsync(a => a.Id == accountId);
        if (account == null)
            throw new Exception("Account not found");

        if (dto.BankName != null) account.BankName = dto.BankName;
        if (dto.BankCode != null) account.BankCode = dto.BankCode;
        if (dto.AccountName != null) account.AccountName = dto.AccountName;
        if (dto.AccountNumber != null) account.AccountNumber = dto.AccountNumber;
        if (dto.IsActive != null) account.IsActive = dto.IsActive.Value;

        await _db.SaveChangesAsync();

        return account;
    }

    public async Task DeleteAccount(Guid accountId)
    {
        var account = await _db.PaymentAccounts.FirstOrDefaultAsync(a => a.Id == accountId);
        if (account == null)
            throw new Exception("Account not found");

        _db.PaymentAccounts.Remove(account);
        await _db.SaveChangesAsync();
    }
}