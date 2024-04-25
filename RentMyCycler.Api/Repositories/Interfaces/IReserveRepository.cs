using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories.Interfaces;

public interface IReserveRepository
{
    //Método para guardar las reservaciones
    Task<Reserves> SaveAsync(Reserves reserves);
    
    //Método para actualizar las reservaciones
    Task<Reserves> UpdateAsync(Reserves reserves);
    
    //Método para retornar una lista de las reservaciones
    Task<List<Reserves>> GetAllAsync();
    
    //Método para retornar el id de la reservación que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una reservación por id
    Task<Reserves> GetByIdAsync(int id);
}