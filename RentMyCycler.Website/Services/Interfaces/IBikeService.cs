using RentMyCycler.Api.DTO;
using RentMyCycler.Core.http;

namespace RentMyCycler.Website.Services.Interfaces;

public interface IBikeService
{
    Task<Response<List<BikeDto>>> GetAllAsync();

    Task<Response<BikeDto>> GetById(int id);

    Task<Response<BikeDto>> SaveAsync(BikeDto BikeDto);

    Task<Response<BikeDto>> UpdateAsync(BikeDto BikeDto);

    Task<Response<bool>> DeleteAsync(int id);
}