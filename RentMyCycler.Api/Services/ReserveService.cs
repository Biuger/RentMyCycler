using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Services;

public class ReserveService: IReserveService
{
    private readonly IReserveRepository _reserveRepository;
    public ReserveService(IReserveRepository reserveRepository)
    {
        _reserveRepository = reserveRepository;
    }
    
    public async Task<bool> ReserveExist(int id)
    {
        var reserve = await _reserveRepository.GetByIdAsync(id);

        return (reserve != null);
    }

    public async Task<ReserveDto> SaveAsync(ReserveDto reserveDto)
    {
        var reserve = new Reserves
        {
            Id_user = reserveDto.Id_user, 
            Id_bike = reserveDto.Id_bike,
            Start_date = reserveDto.Start_date,
            Deliver_date = reserveDto.Deliver_date,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        reserve = await _reserveRepository.SaveAsync(reserve);
        reserveDto.id = reserve.id;
        return reserveDto;
    }

    public async Task<ReserveDto> UpdateAsync(ReserveDto reserveDto)
    {
        var reserve = await _reserveRepository.GetByIdAsync(reserveDto.id);
        

        if (reserve == null)
        {
            throw new Exception("Reservation not found");
        }
        reserve.Id_user = reserveDto.Id_user;
        reserve.Id_bike = reserveDto.Id_bike;
        reserve.Start_date = reserveDto.Start_date;
        reserve.Deliver_date = reserveDto.Deliver_date;
        reserve.UpdatedBy = "";
        reserve.UpdatedDate = DateTime.Now;
        await _reserveRepository.UpdateAsync(reserve);
        return reserveDto;
    }

    public async Task<List<ReserveDto>> GetAllAsync()
    {
        var reserves = await _reserveRepository.GetAllAsync();
        var reservesDto = reserves.Select(c => new ReserveDto(c)).ToList();

        return reservesDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _reserveRepository.DeleteAsync(id);
    }

    public async Task<ReserveDto> GetByIdAsync(int id)
    {
        var reserve = await _reserveRepository.GetByIdAsync(id);
        if (reserve == null)
            throw new Exception("Reservation not found");
        var reserveDto = new ReserveDto(reserve);
        return reserveDto;
    }
}