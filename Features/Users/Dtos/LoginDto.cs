using System.ComponentModel.DataAnnotations;

namespace PayBridge.Features.Users.Dtos;


public class LoginDto
{
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters long")]
    public required string Password { get; set; }
}