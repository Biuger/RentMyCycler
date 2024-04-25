using RentMyCycler.Api.DTO;

namespace RentMyCycler.Api.Services.Interfaces;

public interface IPaymentService
{

    Task<bool> PaymentExist(int id);
    
    
    //Método para guardar el método de pago
    Task<PaymentDto> SaveAsync(PaymentDto payment);
    
    //Método para actualizar el método de pago
    Task<PaymentDto> UpdateAsync(PaymentDto payment);
    
    //Método para retornar una lista de los métodos de pago
    Task<List<PaymentDto>> GetAllAsync();
    
    //Método para retornar el id del método de pago que se borró
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener un método de pago por id
    Task<PaymentDto> GetByIdAsync(int id);
}