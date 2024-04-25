using System.Data.Common;

namespace RentMyCycler.Api.DataAccess.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }
}