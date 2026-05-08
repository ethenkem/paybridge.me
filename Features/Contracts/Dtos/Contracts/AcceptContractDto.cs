namespace PayBridge.Features.Contracts.Dtos.Contracts;


public class AcceptContractDto
{
    public required Guid ContractId { get; set; }
    public required Guid ClientId { get; set; }
}