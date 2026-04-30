
using PayBridge.Features.Users;

namespace PayBridge.Features.Contracts;

public class Contract
{
    public Guid Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


