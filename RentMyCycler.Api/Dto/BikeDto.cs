using System.ComponentModel.DataAnnotations;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.DTO
{
    public class BikeDto : DtoBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, ErrorMessage = "Ingrese un valor máximo de 50 caracteres")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, ErrorMessage = "Ingrese un valor máximo de 50 caracteres")]
        public string Model { get; set; }
        
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener números enteros")]
        public int Id_BikeCategory { get; set; }

        [StringLength(100, ErrorMessage = "La descripción debe tener como máximo 100 caracteres")]
        public string Description { get; set; }

        [StringLength(50, ErrorMessage = "Ingrese un valor máximo de 50 caracteres")]
        public string Colour { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Availability { get; set; }

        [RegularExpression("^(New|Used|Reconditioned)$", ErrorMessage = "La condición de la bicicleta debe ser Nuevo, Usado o Reacondicionado")]
        public string Condition_bike { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El costo de alquiler debe ser mayor o igual a cero")]
        public decimal Rental_cost { get; set; }

        public BikeDto()
        {
        }

        public BikeDto(Bikes bikes)
        {
            id = bikes.id;
            Brand = bikes.Brand;
            Model = bikes.Model;
            Description = bikes.Description;
            Colour = bikes.Colour;
            Condition_bike = bikes.Condition_bike;
            Availability = bikes.Availability;
            Rental_cost = bikes.Rental_cost;
        }
    }
}