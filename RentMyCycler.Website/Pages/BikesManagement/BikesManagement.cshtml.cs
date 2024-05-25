using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Website.Pages.BikesManagement;

public class BikesManagement : PageModel
{
    public List<Bikes> Bikes { get; set; }
    public string Model { get; set; }
    public bool Availability { get; set; }
    public string ImageUrl { get; set; }
    public void OnGet()
    {
        Bikes = new List<Bikes>
        {
            new Bikes { id = 1, Model = "user1", Availability = true},
            new Bikes { id = 2, Model = "user2", Availability =true },
            new Bikes { id = 3, Model = "user3", Availability = true }
        };
    }
}