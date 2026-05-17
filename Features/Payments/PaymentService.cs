using PayBridge.Infrastructure.Data;

namespace PayBridge.Features.Payments;


public class PaymentService
{
    private readonly AppDbContext _db;
    public PaymentService(AppDbContext db)
    {
        _db = db;
    }
}