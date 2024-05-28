using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages;

public class IndexModel : PageModel
{
    private readonly IUserService _service;
    public List<string> Errors { get; set; } = new List<string>();
    public string ErrorMessage { get; set; }
        
    public IndexModel(IUserService service)
    {
        _service = service;
    }
    [BindProperty] public UserDto UserDto { get; set; }
    
    public async Task<IActionResult> OnGet()
            {
                return Page();
            }
            
            public async Task<IActionResult> OnPostAsync()
            {
                
                var response = await _service.LoginAsync(UserDto.Email, UserDto.Password);
                if (response.Data != null)
                {
                    var userRole = response.Data.Admin; 

                    if (userRole)
                    {
                        return RedirectToPage("/AdminMenu/AdminMenu"); 
                    }
                    else
                    {
                        var id = response.Data.id;
                        TempData["id"] = id;
                        return RedirectToPage("/Home/Home"); 
                    }
                }
                Errors = response.Errors;

                if (Errors.Count > 0)
                {
                    ErrorMessage = "Invalid email or password.";
                    return Page();
                }

                return Page();
            }
    
}