using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using PayBridge.Features.Contracts.Dtos.Contracts;
using PayBridge.Features.Contracts.Dtos.Milestones;
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
        if (!Guid.TryParse(userId, out Guid userIdGuid))
        {
            throw new ValidationException("Invalid user ID");
        }
        var contract = await _contractService.CreateContractHandler(userIdGuid, createContractDto);
        return Ok(new ApiResponse<Contract>
        {
            success = true,
            message = "Contract created successfully",
            data = contract
        });
    }

    [HttpPost("{contractId}/add-milestone")]
    public async Task<IActionResult> AddMilestone([FromBody] CreateMilestone createMilestone, Guid contractId)
    {
        var milestone = await _contractService.AddMilestoneHandler(contractId, createMilestone);
        return Ok(new ApiResponse<Milestone>
        {
            success = true,
            message = "Milestone added successfully",
            data = milestone
        });
    }


    [HttpGet("my-contracts")]
    public async Task<IActionResult> GetContract()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        if (!Guid.TryParse(userId, out Guid userIdGuid))
        {
            throw new ValidationException("Invalid user ID");
        }
        var contracts = await _contractService.GetContracstHandler(userIdGuid);
        return Ok(new ApiResponse<List<Contract>>
        {
            success = true,
            message = "Contracts fetched successfully",
            data = contracts
        });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateContract([FromBody] UpdateContractDto updateContractDto, Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out Guid userIdGuid))
        {
            throw new ValidationException("Invalid user ID");
        }
        var contract = await _contractService.UpdateContractHandler(userIdGuid, id, updateContractDto);
        return Ok(new ApiResponse<Contract>
        {
            success = true,
            message = "Contract updated successfully",
            data = contract
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContract(Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        if (!Guid.TryParse(userId, out Guid userIdGuid))
        {
            throw new ValidationException("Invalid user ID");
        }
        await _contractService.DeleteContractHandler(userIdGuid, id);
        return Ok(new ApiResponse<object>
        {
            success = true,
            message = "Contract deleted successfully"
        });
    }


}
