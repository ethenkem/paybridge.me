using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayBridge.Features.Payments.Models;

namespace PayBridge.Infrastructure.Data.Configurations;


public class PaymentAccountConfiguration : IEntityTypeConfiguration<PaymentAccount>
{
    public void Configure(EntityTypeBuilder<PaymentAccount> builder)
    {
        builder.HasOne(p => p.UserProfile)
        .WithMany(u => u.PaymentAccounts)
        .HasForeignKey(p => p.userId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}