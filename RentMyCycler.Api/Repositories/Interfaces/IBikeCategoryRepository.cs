using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories.Interfaces;

public interface IBikeCategoryRepository
{
    //Método para guardar las categorías de bicicletas
    Task<BikeCategories> SaveAsync(BikeCategories bikeCategories);
    
    //Método para actualizar las categorías de bicicletas
    Task<BikeCategories> UpdateAsync(BikeCategories bikeCategories);
    
    //Método para retornar una lista de las categorías de bicicletas
    Task<List<BikeCategories>> GetAllAsync();
    
    //Método para retornar el id de la categoría de bicicleta que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una categoría de bicicleta por id
    Task<BikeCategories> GetByIdAsync(int id);
    Task<BikeCategories> GetByName(string name, int id = 0);
}