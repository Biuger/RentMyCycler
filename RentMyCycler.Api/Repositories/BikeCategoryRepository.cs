using Dapper;
using Dapper.Contrib.Extensions;
using RentMyCycler.Api.DataAccess.Interfaces;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories;


public class BikeCategoryRepository : IBikeCategoryRepository
{
    private readonly IDbContext _dbContext;

    public BikeCategoryRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<BikeCategories> SaveAsync(BikeCategories bikeCategoryCategories)
    {
        bikeCategoryCategories.id = await _dbContext.Connection.InsertAsync(bikeCategoryCategories);
        return bikeCategoryCategories;
    }

    public async Task<BikeCategories> UpdateAsync(BikeCategories bikeCategoryCategories)
    {
        await _dbContext.Connection.UpdateAsync(bikeCategoryCategories);
        return bikeCategoryCategories;
    }

    public async Task<List<BikeCategories>> GetAllAsync()
    {
        const string sql = "SELECT * FROM BikeCategories WHERE IsDeleted = 0";
        var bikeCategoryCategories = await _dbContext.Connection.QueryAsync<BikeCategories>(sql);

        return bikeCategoryCategories.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var bikeCategory = await GetByIdAsync(id);
        if (bikeCategory == null)
            return false;
        bikeCategory.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(bikeCategory);
    }

    public async Task<BikeCategories> GetByIdAsync(int id)
    {
        var bikeCategory = await _dbContext.Connection.GetAsync<BikeCategories>(id);
        if (bikeCategory == null)
            return null;
        return bikeCategory.isDeleted == true ? null : bikeCategory;
       
    }
}