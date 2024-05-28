using RentMyCycler.Api.DTO;
using RentMyCycler.Core.http;

namespace RentMyCycler.Website.Services.Interfaces;

public interface IBikeCategoryService
{
    Task<Response<List<BikeCategoryDto>>> GetAllAsync();

    Task<Response<BikeCategoryDto>> GetById(int id);

    Task<Response<BikeCategoryDto>> SaveAsync(BikeCategoryDto BikeCategoryDto);

    Task<Response<BikeCategoryDto>> UpdateAsync(BikeCategoryDto BikeCategoryDto);

    Task<Response<bool>> DeleteAsync(int id);
}