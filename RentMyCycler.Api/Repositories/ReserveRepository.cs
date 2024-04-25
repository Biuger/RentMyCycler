using Dapper;
using Dapper.Contrib.Extensions;
using RentMyCycler.Api.DataAccess.Interfaces;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories;


public class ReserveRepository : IReserveRepository
{
    private readonly IDbContext _dbContext;

    public ReserveRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Reserves> SaveAsync(Reserves reserves)
    {
        reserves.id = await _dbContext.Connection.InsertAsync(reserves);
        return reserves;
    }

    public async Task<Reserves> UpdateAsync(Reserves reserves)
    {
        await _dbContext.Connection.UpdateAsync(reserves);
        return reserves;
    }

    public async Task<List<Reserves>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Reserves WHERE IsDeleted = 0";
        var reserves = await _dbContext.Connection.QueryAsync<Reserves>(sql);

        return reserves.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var reserve = await GetByIdAsync(id);
        if (reserve == null)
            return false;
        reserve.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(reserve);
    }

    public async Task<Reserves> GetByIdAsync(int id)
    {
        var reserve = await _dbContext.Connection.GetAsync<Reserves>(id);
        if (reserve == null)
            return null;
        return reserve.isDeleted == true ? null : reserve;
       
    }
}