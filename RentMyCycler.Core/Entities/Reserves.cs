using Tecnm.Ecommerce.Core.Entities;

namespace RentMyCycler.Core.Entities;

public class Reserves: EntityBase
{
    public int Id_user { get; set; }
    public int Id_bike { get; set; }
    public DateOnly Start_date { get; set; }
    public DateOnly Deliver_date { get; set; }
}