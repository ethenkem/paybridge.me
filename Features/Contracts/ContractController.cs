using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using PayBridge.Features.Contracts.Dtos.Contracts;
using PayBridge.Shared;

namespace PayBridge.Features.Contracts;

[ApiController]
[Authorize]
[Route("api/contracts")]
public class ContractController : ControllerBase
{
    private readonly ContractService _contractService;
    public ContractController(ContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateContract([FromBody] CreateContractDto createContractDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        Guid userIdInt;
        if (!Guid.TryParse(userId, out userIdInt))
        {
            return BadRequest(new ApiResponse<object>
            {
                success = false,
                message = "Invalid user ID",
                data = null
            });
        }
        var response = await _contractService.CreateContractHandler(userIdInt, createContractDto);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("my-contracts")]
    public async Task<IActionResult> GetContract()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        Guid userIdInt;
        if (!Guid.TryParse(userId, out userIdInt))
        {
            return BadRequest(new ApiResponse<object>
            {
                success = false,
                message = "Invalid user ID",
                data = null
            });
        }
        var response = await _contractService.GetContracstHandler(userIdInt);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateContract([FromBody] UpdateContractDto updateContractDto, Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Guid userIdUid;
        if (!Guid.TryParse(userId, out userIdUid))
        {
            return BadRequest(new ApiResponse<object>
            {
                success = false,
                message = "Invalid user ID",
                data = null
            });
        }
        var response = await _contractService.UpdateContractHandler(userIdUid, id, updateContractDto);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContract(Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        Guid userIdInt;
        if (!Guid.TryParse(userId, out userIdInt))
        {
            return BadRequest(new ApiResponse<object>
            {
                success = false,
                message = "Invalid user ID",
                data = null
            });
        }
        var response = await _contractService.DeleteContractHandler(userIdInt, id);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

}
