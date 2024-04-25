using Tecnm.Ecommerce.Core.Entities;

namespace RentMyCycler.Core.Entities;

public class UsageStatistics: EntityBase
{
    public int Id_bike { get; set; }
    public int Times_perDay { get; set; }
    public decimal Income_perDay { get; set; }

}