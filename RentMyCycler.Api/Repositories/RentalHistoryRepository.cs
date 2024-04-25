using Dapper;
using Dapper.Contrib.Extensions;
using RentMyCycler.Api.DataAccess.Interfaces;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories;


public class RentalHistoryRepository : IRentalHistoryRepository
{
    private readonly IDbContext _dbContext;

    public RentalHistoryRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<RentalHistory> SaveAsync(RentalHistory rentalHistory)
    {
        rentalHistory.id = await _dbContext.Connection.InsertAsync(rentalHistory);
        return rentalHistory;
    }

    public async Task<RentalHistory> UpdateAsync(RentalHistory rentalHistory)
    {
        await _dbContext.Connection.UpdateAsync(rentalHistory);
        return rentalHistory;
    }

    public async Task<List<RentalHistory>> GetAllAsync()
    {
        const string sql = "SELECT * FROM RentalHistory WHERE IsDeleted = 0";
        var rentalHistory = await _dbContext.Connection.QueryAsync<RentalHistory>(sql);

        return rentalHistory.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var rentalHistory = await GetByIdAsync(id);
        if (rentalHistory == null)
            return false;
        rentalHistory.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(rentalHistory);
    }

    public async Task<RentalHistory> GetByIdAsync(int id)
    {
        var rentalHistory = await _dbContext.Connection.GetAsync<RentalHistory>(id);
        if (rentalHistory == null)
            return null;
        return rentalHistory.isDeleted == true ? null : rentalHistory;
       
    }
}