using Dapper;
using Dapper.Contrib.Extensions;
using RentMyCycler.Api.DataAccess.Interfaces;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories;


public class PaymentRepository : IPaymentRepository
{
    private readonly IDbContext _dbContext;

    public PaymentRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Payments> SaveAsync(Payments payments)
    {
        payments.id = await _dbContext.Connection.InsertAsync(payments);
        return payments;
    }

    public async Task<Payments> UpdateAsync(Payments payments)
    {
        await _dbContext.Connection.UpdateAsync(payments);
        return payments;
    }

    public async Task<List<Payments>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Payments WHERE IsDeleted = 0";
        var payments = await _dbContext.Connection.QueryAsync<Payments>(sql);

        return payments.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var payment = await GetByIdAsync(id);
        if (payment == null)
            return false;
        payment.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(payment);
    }

    public async Task<Payments> GetByIdAsync(int id)
    {
        var payment = await _dbContext.Connection.GetAsync<Payments>(id);
        if (payment == null)
            return null;
        return payment.isDeleted == true ? null : payment;
       
    }
}