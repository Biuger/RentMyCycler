using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Repositories.Interfaces;

public interface IPaymentRepository
{
    //Método para guardar el hisotiral de pagos
    Task<Payments> SaveAsync(Payments payments);
    
    //Método para actualizar el hisotiral de pagos
    Task<Payments> UpdateAsync(Payments payments);
    
    //Método para retornar una lista del hisotiral de pagos
    Task<List<Payments>> GetAllAsync();
    
    //Método para retornar el id del hisotiral de pagos que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener hisotiral de pagos por id
    Task<Payments> GetByIdAsync(int id);
}