using RentMyCycler.Api.DTO;

namespace RentMyCycler.Api.Services.Interfaces;

public interface IReserveService
{

    Task<bool> ReserveExist(int id);
    
    
    //Método para guardar la reservación
    Task<ReserveDto> SaveAsync(ReserveDto reserve);
    
    //Método para actualizar la reservación
    Task<ReserveDto> UpdateAsync(ReserveDto reserve);
    
    //Método para retornar una lista de las reservaciones
    Task<List<ReserveDto>> GetAllAsync();
    
    //Método para retornar el id de la reservación que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una reservación por id
    Task<ReserveDto> GetByIdAsync(int id);
}