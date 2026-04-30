using Microsoft.AspNetCore.Mvc;
using PayBridge.Shared;

namespace PayBridge.Features.Contracts;

[ApiController]
[Route("api/contracts")]
public class ContractController : ControllerBase
{
    [HttpPost("create")]
    public IActionResult CreateContract()
    {
        return Ok(new ApiResponse<object>
        {
            success = true,
            message = "Contract created successfully",
            data = null
        });
    }

    [HttpGet("my-contracts")]
    public IActionResult GetContract()
    {
        return Ok(new ApiResponse<object>
        {
            success = true,
            message = "Contract fetched successfully",
            data = null
        });
    }
}
