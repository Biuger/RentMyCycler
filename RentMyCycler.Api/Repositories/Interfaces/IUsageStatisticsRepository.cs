using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories.Interfaces;

public interface IUsageStatisticsRepository
{
    //Método para guardar las estadísticas de uso
    Task<UsageStatistics> SaveAsync(UsageStatistics usageStatistics);
    
    //Método para actualizar las estadísticas de uso
    Task<UsageStatistics> UpdateAsync(UsageStatistics usageStatistics);
    
    //Método para retornar una lista de las estadísticas de uso
    Task<List<UsageStatistics>> GetAllAsync();
    
    //Método para retornar el id de las estadísticas de uso que se borraron
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener estadísticas de uso por id
    Task<UsageStatistics> GetByIdAsync(int id);
}