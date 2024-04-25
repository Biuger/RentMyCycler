using System;
using System.ComponentModel.DataAnnotations;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.DTO
{
    public class RentalHistoryDto : DtoBase
    {
       
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener números enteros")]
        public int Id_user { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener números enteros")]
        public int Id_bike { get; set; }
        [Required(ErrorMessage = "El estado del alquiler es obligatorio")]
        public bool Rental_status { get; set; }

        public RentalHistoryDto()
        {
        }

        public RentalHistoryDto(RentalHistory rentalHistory)
        {
            id = rentalHistory.id;
            Id_user = rentalHistory.Id_user;
            Id_bike = rentalHistory.Id_bike;
            Rental_status = rentalHistory.Rental_status;
        }
    }
}