using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories.Interfaces;

public interface IRentalHistoryRepository
{
    //Método para guardar el historial de renta
    Task<RentalHistory> SaveAsync(RentalHistory rentalHistory);
    
    //Método para actualizar el historial de renta
    Task<RentalHistory> UpdateAsync(RentalHistory rentalHistory);
    
    //Método para retornar una lista del historial de renta
    Task<List<RentalHistory>> GetAllAsync();
    
    //Método para retornar el id del hisotiral de renta que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener historial de renta por id
    Task<RentalHistory> GetByIdAsync(int id);
}