using System.ComponentModel.DataAnnotations;

namespace PayBridge.Features.Payments.Dtos.Accounts;

public class UpdateAccountDto
{
    [StringLength(100)]
    public string? BankName { get; set; }

    [StringLength(20)]
    public string? BankCode { get; set; }

    [StringLength(100)]
    public string? AccountName { get; set; }

    [StringLength(15, MinimumLength = 10)]
    [RegularExpression(@"^\d+$", ErrorMessage = "Account number must contain only digits")]
    public string? AccountNumber { get; set; }
    
    public bool? IsActive { get; set; }
}

