using Microsoft.AspNetCore.Mvc;
using PayBridge.Features.Users.Dtos;
using PayBridge.Shared;

namespace PayBridge.Features.Users;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult Register(RegisterDto registerDto)
    {
        return Ok(new ApiResponse<object>
        {
            success = true,
            message = "Please verify your account with the code sent to " + registerDto.Email
        });
    }

    [HttpPost]
    public IActionResult VerifyOtp()
    {
        return Ok(new ApiResponse<object>
        {
            success = true,
            message = "OTP verified",
            data = null
        });
    }
}
