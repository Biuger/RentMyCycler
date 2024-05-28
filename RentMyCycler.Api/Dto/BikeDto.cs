using System.ComponentModel.DataAnnotations;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.DTO
{
    public class BikeDto : DtoBase
    {
        public int id { get; set; }
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

        [RegularExpression("^(New|Used|Bad conditions)$", ErrorMessage = "Only New, Used or Bad conditions")]
        public string Condition_bike { get; set; }

        [Required(ErrorMessage = "El costo de alquiler es obligatorio.")]
       
        public decimal Rental_cost { get; set; }

        public string Image{ get; set; }

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
            Image = bikes.Image;
        }
    }
}