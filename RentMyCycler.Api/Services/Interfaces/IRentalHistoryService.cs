using RentMyCycler.Api.DTO;

namespace RentMyCycler.Api.Services.Interfaces;

public interface IRentalHistoryService
{

    Task<bool> RentalHistoryExist(int id);
    
    
    //Método para guardar el historial de renta
    Task<RentalHistoryDto> SaveAsync(RentalHistoryDto rentalHistory);
    
    //Método para actualizar el historial de renta
    Task<RentalHistoryDto> UpdateAsync(RentalHistoryDto rentalHistory);
    
    //Método para retornar una lista del historial de renta
    Task<List<RentalHistoryDto>> GetAllAsync();
    
    //Método para retornar el id del historial de renta que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener el historial de renta por id
    Task<RentalHistoryDto> GetByIdAsync(int id);
}