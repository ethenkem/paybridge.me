using System.ComponentModel.DataAnnotations;

namespace PayBridge.Features.Users.Dtos;

public class RegisterDto
{
    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 20 characters")]
    public string FullName { get; set; } = default!;
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = default!;
    [Required]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters")]
    public string Password { get; set; } = default!;
}