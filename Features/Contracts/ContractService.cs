using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PayBridge.Features.Contracts.Dtos.Contracts;
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

    public async Task<ApiResponse<object>> CreateContractHandler(Guid userId, CreateContractDto data)
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
        // if (data.Milestones != null)
        // {
        // for i=0; i < data.Milestones.le

        // }
        return new ApiResponse<object>
        {
            success = true,
            message = "Contract created successfully",
            data = newContract,
        };
    }

    public async Task<ApiResponse<List<Contract>>> GetContracstHandler(Guid userId)
    {
        var contracts = await _db.Contracts.Where(x => x.UserId == userId || x.ClientId == userId)
                                .Include(x => x.UserProfile)
                                .Include(x => x.ClientProfile).ToListAsync();
        return new ApiResponse<List<Contract>>
        {
            success = true,
            message = "Contracts fetched successfully",
            data = contracts,
        };
    }
    public async Task<ApiResponse<object>> AcceptContractHandler(AcceptContractDto acceptContractDto)
    {
        var exists = await _db.Contracts.AnyAsync(x => x.Id == acceptContractDto.ContractId);
        if (!exists)
        {
            return new ApiResponse<object>
            {
                success = false,
                message = "Contract not found",
                data = null
            };
        }
        return new ApiResponse<object>
        {
            success = true,
            message = "",
            data = null
        };
    }
    public async Task<ApiResponse<object>> UpdateContractHandler(Guid userId, Guid contractId, UpdateContractDto data)
    {
        var contract = await _db.Contracts.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == contractId);
        if (contract == null)
        {
            return new ApiResponse<object>
            {
                success = false,
                message = "Contract not found",
                data = null,
            };
        }
        if (data.Title != null)
            contract.Title = data.Title;
        if (data.Description != null)
            contract.Description = data.Description;

        _db.Contracts.Update(contract);
        await _db.SaveChangesAsync();
        return new ApiResponse<object>
        {
            success = true,
            message = "Contract updated successfully",
            data = null,
        };
    }
    public async Task<ApiResponse<object>> DeleteContractHandler(Guid userId, Guid contractId)
    {
        var contract = await _db.Contracts.FirstOrDefaultAsync(x => x.Id == contractId && x.UserId == userId);
        if (contract == null)
        {
            return new ApiResponse<object>
            {
                success = false,
                message = "Contract not found",
                data = null,
            };
        }
        _db.Contracts.Remove(contract);
        await _db.SaveChangesAsync();
        return new ApiResponse<object>
        {
            success = true,
            message = "Contract deleted successfully",
            data = null,
        };
    }
}