using System.ComponentModel.DataAnnotations;

namespace PayBridge.Features.Payments.Dtos.Accounts;

public class CreateAccountDto
{
    [Required]
    [StringLength(100)]
    public string BankName { get; set; } = default!;

    [Required]
    [StringLength(20)]
    public string BankCode { get; set; } = default!;

    [Required]
    [StringLength(100)]
    public string AccountName { get; set; } = default!;

    [Required]
    [StringLength(15, MinimumLength = 10)]
    [RegularExpression(@"^\d+$", ErrorMessage = "Account number must contain only digits")]
    public string AccountNumber { get; set; } = default!;
}

