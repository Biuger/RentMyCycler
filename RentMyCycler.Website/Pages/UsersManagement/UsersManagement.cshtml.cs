using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Core.Entities;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.UsersManagement;

public class UsersManagement : PageModel
{
    private readonly IUserService _service;
    
    public List<UserDto> Users { get; set; }

    public UsersManagement(IUserService service)
    {
        Users = new List<UserDto>();
        _service = service;
    }
    public  async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        Users = response.Data;
        
        return Page();
    }
}