using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Website.Pages.UsersManagement;

public class UsersManagement : PageModel
{
    public List<Users> Users { get; set; }
    public void OnGet()
    {
        Users = new List<Users>
        {
            new Users { id = 1, Username = "user1", Email = "user1@example.com" },
            new Users { id = 2, Username = "user2", Email = "user2@example.com" },
            new Users { id = 3, Username = "user3", Email = "user3@example.com" }
        };
    }
}