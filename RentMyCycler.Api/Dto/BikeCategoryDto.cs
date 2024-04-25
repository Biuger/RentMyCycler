using System.ComponentModel.DataAnnotations;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.DTO
{
    public class BikeCategoryDto : DtoBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, ErrorMessage = "Ingrese un valor máximo de 50 caracteres")]
        public string Bike_type { get; set; }

        [StringLength(100, ErrorMessage = "La descripción debe tener como máximo 100 caracteres")]
        public string Description_Bike { get; set; }

        public BikeCategoryDto()
        {
        }

        public BikeCategoryDto(BikeCategories bikeCategories)
        {
            id = bikeCategories.id;
            Bike_type = bikeCategories.Bike_type;
            Description_Bike = bikeCategories.Description_Bike;
        }
    }
}