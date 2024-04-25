using System.ComponentModel.DataAnnotations;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.DTO
{
    public class UsageStatisticsDto : DtoBase
    {
        [Required(ErrorMessage = "El ID de bicicleta es obligatorio")]
        public int Id_bike { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo solo puede contener números enteros")]
        [Required(ErrorMessage = "El número de veces por día es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El número de veces por día debe ser mayor o igual a cero")]
        public int Times_perDay { get; set; }

        [Required(ErrorMessage = "El ingreso por día es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El ingreso por día debe ser mayor o igual a cero")]
        public decimal Income_perDay { get; set; }

        public UsageStatisticsDto()
        {
        }

        public UsageStatisticsDto(UsageStatistics usageStatistics)
        {
            id = usageStatistics.id;
            Id_bike = usageStatistics.Id_bike;
            Times_perDay = usageStatistics.Times_perDay;
            Income_perDay = usageStatistics.Income_perDay;
        }
    }
}