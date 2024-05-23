using RentMyCycler.Core.http;
using RentMyCycler.Api.DTO;

namespace RentMyCycler.Website.Services.Interfaces;

public interface IUserService
{
    public interface IProductCategoryService
    {
        Task<Response<List<UserDto>>> GetAllAsync();

        Task<Response<UserDto>> GetById(int id);

        Task<Response<UserDto>> SaveAsync(UserDto userDto);

        Task<Response<UserDto>> UpdateAsync(UserDto userDto);

        Task<Response<bool>> DeleteAsync(int id);
    }
}