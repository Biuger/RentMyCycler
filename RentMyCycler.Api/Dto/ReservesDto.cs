using System.ComponentModel.DataAnnotations;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.DTO;

public class ReserveDto: DtoBase
{
    [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener números enteros")]
    public int Id_user { get; set; }
    [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener números enteros")]
    public int Id_bike { get; set; }
    [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
    public DateOnly Start_date { get; set; }
    [Required(ErrorMessage = "La fecha de entrega es obligatoria")]
    public DateOnly Deliver_date { get; set; }

    public ReserveDto()
    {
        
    }

    public ReserveDto(Reserves reserves)
    {
        id = reserves.id;
        Id_user = reserves.Id_user;
        Id_bike = reserves.Id_bike; 
        Start_date = reserves.Start_date;
        Deliver_date = reserves.Deliver_date;
    }
}