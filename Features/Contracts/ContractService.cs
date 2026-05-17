using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PayBridge.Features.Contracts.Dtos.Contracts;
using PayBridge.Features.Contracts.Dtos.Milestones;
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

    public async Task<Contract> CreateContractHandler(Guid userId, CreateContractDto data)
    {
        var exists = await _db.Contracts.AnyAsync(x => x.Title == data.Title && x.UserId == userId);
        if (exists)
        {
            throw new ConflictException("Contract with this title already exists");
        }
        var newContract = new Contract
        {
            Title = data.Title,
            Description = data.Description,
            UserId = userId,
        };
        this._db.Contracts.Add(newContract);
        await this._db.SaveChangesAsync();
        return newContract;
    }

    public async Task<Milestone> AddMilestoneHandler(Guid contractId, CreateMilestone data)
    {
        var exists = await _db.Contracts.AnyAsync(x => x.Id == contractId);
        if (!exists)
        {
            throw new NotFoundException("Contract not found");
        }
        var newMilestone = new Milestone
        {
            ContractId = contractId,
            Description = data.Description,
            Amount = data.Amount,
            Order = data.Order,
            Status = MilestoneStatus.Pending,
        };
        this._db.Milestones.Add(newMilestone);
        await this._db.SaveChangesAsync();
        return newMilestone;
    }

    public async Task<List<Contract>> GetContracstHandler(Guid userId)
    {
        return await _db.Contracts.Where(x => x.UserId == userId || x.ClientId == userId)
                                .Include(x => x.UserProfile)
                                .Include(x => x.ClientProfile).ToListAsync();
    }

    public async Task AcceptContractHandler(AcceptContractDto acceptContractDto)
    {
        var exists = await _db.Contracts.AnyAsync(x => x.Id == acceptContractDto.ContractId);
        if (!exists)
        {
            throw new NotFoundException("Contract not found");
        }
    }

    public async Task<Contract> UpdateContractHandler(Guid userId, Guid contractId, UpdateContractDto data)
    {
        var contract = await _db.Contracts.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == contractId);
        if (contract == null)
        {
            throw new NotFoundException("Contract not found");
        }
        if (data.Title != null)
            contract.Title = data.Title;
        if (data.Description != null)
            contract.Description = data.Description;

        _db.Contracts.Update(contract);
        await _db.SaveChangesAsync();
        return contract;
    }

    public async Task DeleteContractHandler(Guid userId, Guid contractId)
    {
        var contract = await _db.Contracts.FirstOrDefaultAsync(x => x.Id == contractId && x.UserId == userId);
        if (contract == null)
        {
            throw new NotFoundException("Contract not found");
        }
        _db.Contracts.Remove(contract);
        await _db.SaveChangesAsync();
    }
}