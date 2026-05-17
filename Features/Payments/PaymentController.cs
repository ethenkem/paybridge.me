using Microsoft.AspNetCore.Mvc;
using PayBridge.Features.Payments.Dtos.Accounts;
using PayBridge.Features.Payments.Models;
using PayBridge.Shared;

namespace PayBridge.Features.Payments;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _paymentService;

    public PaymentController(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("trigger/{milestoneId}")]
    public async Task<ActionResult<ApiResponse<Models.Payment>>> TriggerPayment(int milestoneId)
    {
        var payment = await _paymentService.TriggerPayment(milestoneId);
        return Ok(new ApiResponse<Models.Payment>
        {
            success = true,
            data = payment,
            message = "Payment triggered successfully"
        });
    }

    [HttpPost("release/{paymentId}")]
    public async Task<ActionResult<ApiResponse<Models.Payment>>> ReleasePayment(Guid paymentId)
    {
        var payment = await _paymentService.ReleasePayment(paymentId);
        return Ok(new ApiResponse<Models.Payment>
        {
            success = true,
            data = payment,
            message = "Payment released successfully"
        });
    }

    // Account Management
    [HttpGet("accounts/user/{userId}")]
    public async Task<ActionResult<ApiResponse<List<PaymentAccount>>>> GetAccounts(Guid userId)
    {
        var accounts = await _paymentService.GetAccounts(userId);
        return Ok(new ApiResponse<List<PaymentAccount>>
        {
            success = true,
            data = accounts,
            message = "Accounts retrieved successfully"
        });
    }

    [HttpPost("accounts/{userId}")]
    public async Task<ActionResult<ApiResponse<PaymentAccount>>> AddAccount(Guid userId, [FromBody] CreateAccountDto dto)
    {
        var account = await _paymentService.AddAccount(userId, dto);
        return Ok(new ApiResponse<PaymentAccount>
        {
            success = true,
            data = account,
            message = "Account added successfully"
        });
    }

    [HttpPut("accounts/{accountId}")]
    public async Task<ActionResult<ApiResponse<PaymentAccount>>> UpdateAccount(Guid accountId, [FromBody] UpdateAccountDto dto)
    {
        var account = await _paymentService.UpdateAccount(accountId, dto);
        return Ok(new ApiResponse<PaymentAccount>
        {
            success = true,
            data = account,
            message = "Account updated successfully"
        });
    }

    [HttpDelete("accounts/{accountId}")]
    public async Task<ActionResult<ApiResponse<object>>> DeleteAccount(Guid accountId)
    {
        await _paymentService.DeleteAccount(accountId);
        return Ok(new ApiResponse<object>
        {
            success = true,
            message = "Account deleted successfully"
        });
    }
}