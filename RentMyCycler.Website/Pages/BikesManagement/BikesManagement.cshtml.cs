using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;

using RentMyCycler.Core.Entities;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.BikesManagement;

public class BikesManagement : PageModel
{
    private readonly IBikeService _service;
    
    public List<BikeDto> Bikes { get; set; }

    public BikesManagement(IBikeService service)
    {
        Bikes = new List<BikeDto>();
        _service = service;
    }
    
    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        Bikes = response.Data;
        
        return Page();
    }
}