using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Services;

public class BikeCategoryService: IBikeCategoryService
{
    private readonly IBikeCategoryRepository _bikeCategoryRepository;
    public BikeCategoryService(IBikeCategoryRepository bikeCategoryRepository)
    {
        _bikeCategoryRepository = bikeCategoryRepository;
    }
    
    public async Task<bool> BikeCategoryExist(int id)
    {
        var bikeCategory = await _bikeCategoryRepository.GetByIdAsync(id);

        return (bikeCategory != null);
    }

    public async Task<BikeCategoryDto> SaveAsync(BikeCategoryDto bikeCategoryDto)
    {
        var bikeCategory = new BikeCategories
        {
            Bike_type = bikeCategoryDto.Bike_type, 
            Description_Bike = bikeCategoryDto.Description_Bike,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        bikeCategory = await _bikeCategoryRepository.SaveAsync(bikeCategory);
        bikeCategoryDto.id = bikeCategory.id;
        return bikeCategoryDto;
    }

    public async Task<BikeCategoryDto> UpdateAsync(BikeCategoryDto bikeCategoryDto)
    {
        var bikeCategory = await _bikeCategoryRepository.GetByIdAsync(bikeCategoryDto.id);
        

        if (bikeCategory == null)
        {
            throw new Exception("Bike category not found");
        }
        bikeCategory.Bike_type = bikeCategoryDto.Bike_type;
        bikeCategory.Description_Bike = bikeCategoryDto.Description_Bike;
        bikeCategory.UpdatedBy = "";
        bikeCategory.UpdatedDate = DateTime.Now;
        await _bikeCategoryRepository.UpdateAsync(bikeCategory);
        return bikeCategoryDto;
    }

    public async Task<List<BikeCategoryDto>> GetAllAsync()
    {
        var bikeCategorys = await _bikeCategoryRepository.GetAllAsync();
        var bikeCategorysDto = bikeCategorys.Select(c => new BikeCategoryDto(c)).ToList();

        return bikeCategorysDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _bikeCategoryRepository.DeleteAsync(id);
    }

    public async Task<BikeCategoryDto> GetByIdAsync(int id)
    {
        var bikeCategory = await _bikeCategoryRepository.GetByIdAsync(id);
        if (bikeCategory == null)
            throw new Exception("Bike category not found");
        var bikeCategoryDto = new BikeCategoryDto(bikeCategory);
        return bikeCategoryDto;
    }
    
    public async Task<bool> ExistByName(string name, int id = 0)
    {
        var category = await _bikeCategoryRepository.GetByName(name, id);

        return category != null;
    }
}