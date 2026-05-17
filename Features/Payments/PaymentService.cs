using Microsoft.EntityFrameworkCore;
using PayBridge.Features.Contracts;
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
}