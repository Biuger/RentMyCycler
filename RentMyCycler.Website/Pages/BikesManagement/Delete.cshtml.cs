using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.BikesManagement;

public class Delete : PageModel
{
    [BindProperty] public BikeDto BikeDto { get; set; }
    
    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly IBikeService _bike_service;
    private readonly IBikeCategoryService _bikeCategoryService;
    public List<BikeCategoryDto> BikeCategories { get; set; }
    
    public Delete(IBikeService bikeService, IBikeCategoryService bikeCategoryService)
    {
        BikeCategories = new List<BikeCategoryDto>();
        _bike_service = bikeService;
        _bikeCategoryService = bikeCategoryService;
    }
    public  async Task<IActionResult> OnGet(int? id)
    {
        BikeDto = new BikeDto();
        
        var responseBikeCategory = await _bikeCategoryService.GetAllAsync();
        BikeCategories = responseBikeCategory.Data;
        if (id.HasValue)
        {
            //Obtener informacion del servicio API
            var response = await _bike_service.GetById(id.Value);
            BikeDto = response.Data;
        }


        if (BikeDto == null)
        {
            
            return RedirectToPage("/Error");
        }
        
    
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _bike_service.DeleteAsync(BikeDto.id);
        return RedirectToPage("/BikesManagement/BikesManagement");
        
    }
}