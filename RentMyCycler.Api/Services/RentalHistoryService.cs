using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Services;

public class RentalHistoryService: IRentalHistoryService
{
    private readonly IRentalHistoryRepository _rentalHistoryRepository;
    public RentalHistoryService(IRentalHistoryRepository rentalHistoryRepository)
    {
        _rentalHistoryRepository = rentalHistoryRepository;
    }
    
    public async Task<bool> RentalHistoryExist(int id)
    {
        var rentalHistory = await _rentalHistoryRepository.GetByIdAsync(id);

        return (rentalHistory != null);
    }

    public async Task<RentalHistoryDto> SaveAsync(RentalHistoryDto rentalHistoryDto)
    {
        var rentalHistory = new RentalHistory
        {
            Id_user = rentalHistoryDto.Id_user, 
            Id_bike = rentalHistoryDto.Id_bike,
            Rental_status = rentalHistoryDto.Rental_status,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        rentalHistory = await _rentalHistoryRepository.SaveAsync(rentalHistory);
        rentalHistoryDto.id = rentalHistory.id;
        return rentalHistoryDto;
    }

    public async Task<RentalHistoryDto> UpdateAsync(RentalHistoryDto rentalHistoryDto)
    {
        var rentalHistory = await _rentalHistoryRepository.GetByIdAsync(rentalHistoryDto.id);
        

        if (rentalHistory == null)
        {
            throw new Exception("Rental History not found");
        }

        rentalHistory.Id_user = rentalHistoryDto.Id_user;
        rentalHistory.Id_bike = rentalHistoryDto.Id_bike;
        rentalHistory.Rental_status = rentalHistoryDto.Rental_status;
        rentalHistory.UpdatedBy = "";
        rentalHistory.UpdatedDate = DateTime.Now;
        await _rentalHistoryRepository.UpdateAsync(rentalHistory);
        return rentalHistoryDto;
    }

    public async Task<List<RentalHistoryDto>> GetAllAsync()
    {
        var rentalHistorys = await _rentalHistoryRepository.GetAllAsync();
        var rentalHistorysDto = rentalHistorys.Select(c => new RentalHistoryDto(c)).ToList();

        return rentalHistorysDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _rentalHistoryRepository.DeleteAsync(id);
    }

    public async Task<RentalHistoryDto> GetByIdAsync(int id)
    {
        var rentalHistory = await _rentalHistoryRepository.GetByIdAsync(id);
        if (rentalHistory == null)
            throw new Exception("Rental History not found");
        var rentalHistoryDto = new RentalHistoryDto(rentalHistory);
        return rentalHistoryDto;
    }
}