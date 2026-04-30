using PayBridge.Features.Contracts;

namespace PayBridge.Features.Users;

public class User
{
    public int Id { get; set; }
    public Guid PublicUid { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;

    public List<Contract> Contracts { get; set; } = new();

}
