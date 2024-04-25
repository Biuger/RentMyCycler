using Dapper;
using Dapper.Contrib.Extensions;
using RentMyCycler.Api.DataAccess.Interfaces;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories;


public class UsageStatisticsRepository : IUsageStatisticsRepository
{
    private readonly IDbContext _dbContext;

    public UsageStatisticsRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<UsageStatistics> SaveAsync(UsageStatistics usageStatistics)
    {
        usageStatistics.id = await _dbContext.Connection.InsertAsync(usageStatistics);
        return usageStatistics;
    }

    public async Task<UsageStatistics> UpdateAsync(UsageStatistics usageStatistics)
    {
        await _dbContext.Connection.UpdateAsync(usageStatistics);
        return usageStatistics;
    }

    public async Task<List<UsageStatistics>> GetAllAsync()
    {
        const string sql = "SELECT * FROM UsageStatistics WHERE IsDeleted = 0";
        var usageStatistics = await _dbContext.Connection.QueryAsync<UsageStatistics>(sql);

        return usageStatistics.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var usageStatistic = await GetByIdAsync(id);
        if (usageStatistic == null)
            return false;
        usageStatistic.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(usageStatistic);
    }

    public async Task<UsageStatistics> GetByIdAsync(int id)
    {
        var usageStatistic = await _dbContext.Connection.GetAsync<UsageStatistics>(id);
        if (usageStatistic == null)
            return null;
        return usageStatistic.isDeleted == true ? null : usageStatistic;
       
    }
}