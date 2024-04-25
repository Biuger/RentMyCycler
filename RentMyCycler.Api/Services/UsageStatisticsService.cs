using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Services;

public class UsageStatisticsService: IUsageStatisticsService
{
    private readonly IUsageStatisticsRepository _usageStatisticsRepository;
    public UsageStatisticsService(IUsageStatisticsRepository usageStatisticsRepository)
    {
        _usageStatisticsRepository = usageStatisticsRepository;
    }
    
    public async Task<bool> UsageStatisticsExist(int id)
    {
        var usageStatistics = await _usageStatisticsRepository.GetByIdAsync(id);

        return (usageStatistics != null);
    }

    public async Task<UsageStatisticsDto> SaveAsync(UsageStatisticsDto usageStatisticsDto)
    {
        var usageStatistics = new UsageStatistics
        {
            Id_bike = usageStatisticsDto.Id_bike, 
            Times_perDay = usageStatisticsDto.Times_perDay,
            Income_perDay = usageStatisticsDto.Income_perDay,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        usageStatistics = await _usageStatisticsRepository.SaveAsync(usageStatistics);
        usageStatisticsDto.id = usageStatistics.id;
        return usageStatisticsDto;
    }

    public async Task<UsageStatisticsDto> UpdateAsync(UsageStatisticsDto usageStatisticsDto)
    {
        var usageStatistics = await _usageStatisticsRepository.GetByIdAsync(usageStatisticsDto.id);
        

        if (usageStatistics == null)
        {
            throw new Exception("Bike not found");
        }
        usageStatistics.Id_bike = usageStatisticsDto.Id_bike;
        usageStatistics.Times_perDay = usageStatisticsDto.Times_perDay;
        usageStatistics.Income_perDay = usageStatisticsDto.Income_perDay;
        usageStatistics.UpdatedBy = "";
        usageStatistics.UpdatedDate = DateTime.Now;
        await _usageStatisticsRepository.UpdateAsync(usageStatistics);
        return usageStatisticsDto;
    }

    public async Task<List<UsageStatisticsDto>> GetAllAsync()
    {
        var usageStatisticss = await _usageStatisticsRepository.GetAllAsync();
        var usageStatisticssDto = usageStatisticss.Select(c => new UsageStatisticsDto(c)).ToList();

        return usageStatisticssDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _usageStatisticsRepository.DeleteAsync(id);
    }

    public async Task<UsageStatisticsDto> GetByIdAsync(int id)
    {
        var usageStatistics = await _usageStatisticsRepository.GetByIdAsync(id);
        if (usageStatistics == null)
            throw new Exception("Bike not found");
        var usageStatisticsDto = new UsageStatisticsDto(usageStatistics);
        return usageStatisticsDto;
    }
}