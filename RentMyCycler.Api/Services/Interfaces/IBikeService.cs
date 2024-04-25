using RentMyCycler.Api.DTO;

namespace RentMyCycler.Api.Services.Interfaces;

public interface IBikeService
{

    Task<bool> BikeExist(int id);
    
    
    //Método para guardar la bicicleta
    Task<BikeDto> SaveAsync(BikeDto bike);
    
    //Método para actualizar la bicicleta
    Task<BikeDto> UpdateAsync(BikeDto bike);
    
    //Método para retornar una lista de las bicicletas
    Task<List<BikeDto>> GetAllAsync();
    
    //Método para retornar el id de la bicicleta que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una bicicleta por id
    Task<BikeDto> GetByIdAsync(int id);
}