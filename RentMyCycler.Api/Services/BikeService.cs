using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Services;

public class BikeService: IBikeService
{
    private readonly IBikeRepository _bikeRepository;
    public BikeService(IBikeRepository bikeRepository)
    {
        _bikeRepository = bikeRepository;
    }
    
    public async Task<bool> BikeExist(int id)
    {
        var bike = await _bikeRepository.GetByIdAsync(id);

        return (bike != null);
    }

    public async Task<BikeDto> SaveAsync(BikeDto bikeDto)
    {
        var bike = new Bikes
        {
            Brand = bikeDto.Brand, 
            Model = bikeDto.Model,
            Id_BikeCategory = bikeDto.Id_BikeCategory,
            Description = bikeDto.Description,
            Colour = bikeDto.Colour,
            Condition_bike = bikeDto.Condition_bike,
            Availability = bikeDto.Availability,
            Rental_cost = bikeDto.Rental_cost,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        bike = await _bikeRepository.SaveAsync(bike);
        bikeDto.id = bike.id;
        return bikeDto;
    }

    public async Task<BikeDto> UpdateAsync(BikeDto bikeDto)
    {
        var bike = await _bikeRepository.GetByIdAsync(bikeDto.id);
        

        if (bike == null)
        {
            throw new Exception("Bike not found");
        }
        bike.Brand = bikeDto.Brand;
        bike.Model = bikeDto.Model;
        bike.Id_BikeCategory = bikeDto.Id_BikeCategory;
        bike.Description = bikeDto.Description;
        bike.Colour = bikeDto.Colour;
        bike.Condition_bike = bikeDto.Condition_bike;
        bike.Availability = bikeDto.Availability;
        bike.Rental_cost = bikeDto.Rental_cost;
        bike.UpdatedBy = "";
        bike.UpdatedDate = DateTime.Now;
        await _bikeRepository.UpdateAsync(bike);
        return bikeDto;
    }

    public async Task<List<BikeDto>> GetAllAsync()
    {
        var bikes = await _bikeRepository.GetAllAsync();
        var bikesDto = bikes.Select(c => new BikeDto(c)).ToList();

        return bikesDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _bikeRepository.DeleteAsync(id);
    }

    public async Task<BikeDto> GetByIdAsync(int id)
    {
        var bike = await _bikeRepository.GetByIdAsync(id);
        if (bike == null)
            throw new Exception("Bike not found");
        var bikeDto = new BikeDto(bike);
        return bikeDto;
    }
}