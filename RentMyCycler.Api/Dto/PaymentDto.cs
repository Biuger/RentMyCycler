using System.ComponentModel.DataAnnotations;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.DTO;

public class PaymentDto: DtoBase
{
    [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener números enteros")]
    [Required(ErrorMessage = "El ID de la reserva es obligatorio")]
    public int Id_reserve { get; set; }
    [Required(ErrorMessage = "El método de pago es obligatorio")]
    [StringLength(50, ErrorMessage = "Ingrese un valor máximo de 50 caracteres")]
    public string Payment_method { get; set; }
    [Required(ErrorMessage = "El monto del pago es obligatorio")]
    [Range(0, double.MaxValue, ErrorMessage = "El monto del pago debe ser mayor o igual a cero")]
    public decimal Amount { get; set; }
    public PaymentDto()
    {
        
    }

    public PaymentDto(Payments payments)
    {
        id = payments.id;
        Id_reserve = payments.Id_reserve;
        Payment_method = payments.Payment_method; 
        Amount = payments.Amount;
    }
}