using Dapper;
using Dapper.Contrib.Extensions;
using RentMyCycler.Api.DataAccess.Interfaces;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories;


public class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;

    public UserRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Users> SaveAsync(Users users)
    {
        users.id = await _dbContext.Connection.InsertAsync(users);
        return users;
    }

    public async Task<Users> UpdateAsync(Users users)
    {
        await _dbContext.Connection.UpdateAsync(users);
        return users;
    }

    public async Task<List<Users>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Users WHERE IsDeleted = 0";
        var users = await _dbContext.Connection.QueryAsync<Users>(sql);

        return users.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);
        if (user == null)
            return false;
        user.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(user);
    }

    public async Task<Users> GetByIdAsync(int id)
    {
        var user = await _dbContext.Connection.GetAsync<Users>(id);
        if (user == null)
            return null;
        return user.isDeleted == true ? null : user;
       
    }
    public async Task<Users> GetByEmailAsync(string email, string password)
    {
        const string sql = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password AND IsDeleted = 0";
        var user = await _dbContext.Connection.QuerySingleOrDefaultAsync<Users>(sql, new { Email = email,  Password = password });
        return user;
    }

    public async Task<Users> GetLogin (string email, string password)
    {
        return await GetByEmailAsync(email, password);
    }
}