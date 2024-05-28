using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories.Interfaces;

public interface IBikeRepository
{
    //Método para guardar las bicicletas
    Task<Bikes> SaveAsync(Bikes bikes);
    
    //Método para actualizar las bicicletas
    Task<Bikes> UpdateAsync(Bikes bikes);
    
    //Método para retornar una lista de las bicicletas
    Task<List<Bikes>> GetAllAsync();
    
    //Método para retornar el id de la bicicleta que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una bicicleta por id
    Task<Bikes> GetByIdAsync(int id);
    Task<Bikes> GetByName(string name, int id = 0);
}