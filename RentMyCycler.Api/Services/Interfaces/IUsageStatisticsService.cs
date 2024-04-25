using RentMyCycler.Api.DTO;

namespace RentMyCycler.Api.Services.Interfaces;

public interface IUsageStatisticsService
{

    Task<bool> UsageStatisticsExist(int id);
    
    
    //Método para guardar las estadísiticas de uso
    Task<UsageStatisticsDto> SaveAsync(UsageStatisticsDto usageStatistics);
    
    //Método para actualizar las estadísiticas de uso
    Task<UsageStatisticsDto> UpdateAsync(UsageStatisticsDto usageStatistics);
    
    //Método para retornar una lista de las estadísiticas de uso
    Task<List<UsageStatisticsDto>> GetAllAsync();
    
    //Método para retornar el id de las estadísiticas de uso  que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener las estadísiticas de uso por id
    Task<UsageStatisticsDto> GetByIdAsync(int id);
}