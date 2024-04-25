using Tecnm.Ecommerce.Core.Entities;

namespace RentMyCycler.Core.Entities;

public class RentalHistory: EntityBase
{
    public int Id_user { get; set; }
    public int Id_bike { get; set; }
    public bool Rental_status { get; set; }
}