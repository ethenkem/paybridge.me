using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayBridge.Features.Contracts;

namespace PayBridge.Infrastructure.Data.Configurations;

public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
{
    public void Configure(EntityTypeBuilder<Milestone> builder)
    {
        builder.HasOne(m => m.Contract)
        .WithMany(c => c.Milestones)
        .HasForeignKey(m => m.ContractId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
