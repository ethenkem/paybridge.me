using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PayBridge.Features.Contracts.Dtos;
using PayBridge.Infrastructure.Data;
using PayBridge.Shared;

namespace PayBridge.Features.Contracts;

public class ContractService
{
    private readonly AppDbContext _db;

    public ContractService(AppDbContext db)
    {
        this._db = db;
    }

    public async Task<ApiResponse<object>> CreateContractHandler(int userId, CreateContractDto data)
    {
        var exists = await _db.Contracts.AnyAsync(x => x.Title == data.Title && x.UserId == userId);
        if (exists)
        {
            return new ApiResponse<object>
            {
                success = false,
                message = "Contract with this title already exists",
                data = null,
            };
        }
        var newContract = new Contract
        {
            Title = data.Title,
            Description = data.Description,
            UserId = userId,
        };
        this._db.Contracts.Add(newContract);
        await this._db.SaveChangesAsync();
        return new ApiResponse<object>
        {
            success = true,
            message = "Contract created successfully",
            data = newContract,
        };
    }

    public async Task<ApiResponse<List<Contract>>> GetContracstHandler(int userId)
    {
        var contracts = await _db.Contracts.Where(x => x.UserId == userId).ToListAsync();
        return new ApiResponse<List<Contract>>
        {
            success = true,
            message = "Contracts fetched successfully",
            data = contracts,
        };
    }
}