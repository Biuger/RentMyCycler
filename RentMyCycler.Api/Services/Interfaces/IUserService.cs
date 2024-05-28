using RentMyCycler.Api.DTO;

namespace RentMyCycler.Api.Services.Interfaces;

public interface IUserService
{

    Task<bool> UserExist(int id);
    
    
    //Método para guardar usuarios
    Task<UserDto> SaveAsync(UserDto user);
    
    //Método para actualizar usuarios
    Task<UserDto> UpdateAsync(UserDto user);
    
    //Método para retornar una lista de usuarios
    Task<List<UserDto>> GetAllAsync();
    
    //Método para retornar el id del usuario que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener usuarios por id
    Task<UserDto> GetByIdAsync(int id);
    
    // Método para autenticar usuarios
    Task<UserDto> LoginAsync(string email, string password);
    Task<bool> ExistByName(string name, int id = 0);
}