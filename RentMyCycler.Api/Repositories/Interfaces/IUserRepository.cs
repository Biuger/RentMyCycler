using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories.Interfaces;

public interface IUserRepository
{
    //Método para guardar usuarios 
    Task<Users> SaveAsync(Users users);
    
    //Método para actualizar usuarios 
    Task<Users> UpdateAsync(Users users);
    
    //Método para retornar una lista de usuarios 
    Task<List<Users>> GetAllAsync();
    
    //Método para retornar el id del usuario que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener un usuario por id
    Task<Users> GetByIdAsync(int id);
}