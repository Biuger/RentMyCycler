using Dapper;
using Dapper.Contrib.Extensions;
using RentMyCycler.Api.DataAccess.Interfaces;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories;


public class BikeRepository : IBikeRepository
{
    private readonly IDbContext _dbContext;

    public BikeRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Bikes> SaveAsync(Bikes bikes)
    {
        bikes.id = await _dbContext.Connection.InsertAsync(bikes);
        return bikes;
    }

    public async Task<Bikes> UpdateAsync(Bikes bikes)
    {
        await _dbContext.Connection.UpdateAsync(bikes);
        return bikes;
    }

    public async Task<List<Bikes>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Bikes WHERE IsDeleted = 0";
        var bikes = await _dbContext.Connection.QueryAsync<Bikes>(sql);

        return bikes.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var bike = await GetByIdAsync(id);
        if (bike == null)
            return false;
        bike.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(bike);
    }

    public async Task<Bikes> GetByIdAsync(int id)
    {
        var bike = await _dbContext.Connection.GetAsync<Bikes>(id);
        if (bike == null)
            return null;
        return bike.isDeleted == true ? null : bike;
       
    }
}