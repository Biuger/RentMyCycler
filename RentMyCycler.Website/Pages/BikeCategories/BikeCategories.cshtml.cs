using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.BikeCategories;

public class BikeCategories : PageModel
{
    private readonly IBikeCategoryService _service;
    
    public List<BikeCategoryDto> bikeCategories { get; set; }

    public BikeCategories(IBikeCategoryService service)
    {
        bikeCategories = new List<BikeCategoryDto>();
        _service = service;
    }
    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        bikeCategories = response.Data;
        
        return Page();
    }
}