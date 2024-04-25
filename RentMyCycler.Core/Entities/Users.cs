using Tecnm.Ecommerce.Core.Entities;

namespace RentMyCycler.Core.Entities;

public class Users: EntityBase
{
    public string Username { get; set; }
    public DateOnly Birthdate { get; set; }
    public string Adress { get; set; }
    public string Cycling_preferences { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Admin { get; set; }
}