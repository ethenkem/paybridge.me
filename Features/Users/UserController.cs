using Microsoft.AspNetCore.Mvc;
using PayBridge.Features.Users.Dtos;
using PayBridge.Shared;

namespace PayBridge.Features.Users;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var response = await _userService.RegisterHandler(registerDto);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPost("verify-otp")]
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
