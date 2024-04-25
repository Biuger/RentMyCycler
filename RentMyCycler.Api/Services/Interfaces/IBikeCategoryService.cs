using RentMyCycler.Api.DTO;

namespace RentMyCycler.Api.Services.Interfaces;

public interface IBikeCategoryService
{

    Task<bool> BikeCategoryExist(int id);
    
    
    //Método para guardar la categoría de bicicleta
    Task<BikeCategoryDto> SaveAsync(BikeCategoryDto bikeCategory);
    
    //Método para actualizar la categoría de bicicleta
    Task<BikeCategoryDto> UpdateAsync(BikeCategoryDto bikeCategory);
    
    //Método para retornar una lista de las categorías de bicicletas
    Task<List<BikeCategoryDto>> GetAllAsync();
    
    //Método para retornar el id de la categoría de bicicleta que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una categoría de bicicleta por id
    Task<BikeCategoryDto> GetByIdAsync(int id);
}