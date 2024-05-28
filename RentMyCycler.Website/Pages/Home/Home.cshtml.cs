using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.Home;

public class Home : PageModel
{
    [BindProperty] public int? id { get; set; }
    private readonly IBikeService _service;
    
    public List<BikeDto> Bikes { get; set; }

    public Home(IBikeService service)
    {
        Bikes = new List<BikeDto>();
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        //La llamada al servicio
        var response = await _service.GetAllAsync();
        Bikes = response.Data;
        id = TempData["id"] as int?;
        return Page();
    }
}