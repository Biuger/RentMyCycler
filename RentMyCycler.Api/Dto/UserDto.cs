using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.DTO;

public class UserDto: DtoBase
{
    public int id { get; set; }
    public string Username { get; set; }
    public DateOnly Birthdate { get; set; }
    public string Adress { get; set; }
    public string Cycling_preferences { get; set; }
    public string Image { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Admin { get; set; }

    public UserDto()
    {
        
    }

    public UserDto(Users users)
    {
        id = users.id;
        Username = users.Username; 
        Birthdate = users.Birthdate;
        Adress = users.Adress;
        Cycling_preferences = users.Cycling_preferences;
        Image = users.Image;
        Email = users.Email; 
        Password = users.Password;
        Admin = users.Admin;
    }
}