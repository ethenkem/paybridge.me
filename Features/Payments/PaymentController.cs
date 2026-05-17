using Microsoft.AspNetCore.Mvc;
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
        try
        {
            var payment = await _paymentService.TriggerPayment(milestoneId);
            return Ok(new ApiResponse<Models.Payment>
            {
                success = true,
                data = payment,
                message = "Payment triggered successfully"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<Models.Payment>
            {
                success = false,
                message = ex.Message
            });
        }
    }

    [HttpPost("release/{paymentId}")]
    public async Task<ActionResult<ApiResponse<Models.Payment>>> ReleasePayment(Guid paymentId)
    {
        try
        {
            var payment = await _paymentService.ReleasePayment(paymentId);
            return Ok(new ApiResponse<Models.Payment>
            {
                success = true,
                data = payment,
                message = "Payment released successfully"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<Models.Payment>
            {
                success = false,
                message = ex.Message
            });
        }
    }

}