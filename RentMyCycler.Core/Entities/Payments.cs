using Tecnm.Ecommerce.Core.Entities;

namespace RentMyCycler.Core.Entities;

public class Payments: EntityBase
{
    public int Id_reserve { get; set; }
    public string Payment_method { get; set; }
    public decimal Amount { get; set; }
}