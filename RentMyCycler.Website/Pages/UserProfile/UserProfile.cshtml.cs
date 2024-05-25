using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentMyCycler.Website.Pages.UserProfile;

public class UserProfile : PageModel
{
    
    [BindProperty]
    public string Username { get; set; }
        
    [BindProperty]
    public DateTime Birthdate { get; set; }
        
    [BindProperty]
    public string Address { get; set; }
        
    [BindProperty]
    public string Preferences { get; set; }
        
    [BindProperty]
    public string Email { get; set; }
        
    [BindProperty]
    public string Password { get; set; }
    public void OnGet()
    {
        
    }
}