using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Core.http;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.BikesManagement;

public class Edit : PageModel
{
    [BindProperty] public BikeDto BikeDto { get; set; }
    public string Label { get; set; }
    
    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly IBikeService _bike_service;
    private readonly IBikeCategoryService _bikeCategoryService;
    public List<BikeCategoryDto> BikeCategories { get; set; }
    [BindProperty]
    public int SelectedOption { get; set; }
    
    public Edit(IBikeService bikeService, IBikeCategoryService bikeCategoryService)
    {
        BikeCategories = new List<BikeCategoryDto>();
        _bike_service = bikeService;
        _bikeCategoryService = bikeCategoryService;
    }
    
    public async Task<IActionResult> OnGet(int? id)
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
        if (id.Value == 0)
        {
            responseBikeCategory = await _bikeCategoryService.GetAllAsync();
            BikeCategories = responseBikeCategory.Data;
            Label = "New Bike";
            return Page();
        }

        if (BikeDto == null)
        {
            
            return RedirectToPage("/Error");
        }
        
        Label = "Editing Bike";
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<BikeDto> response;
        
        if (BikeDto.id > 0)
        {
            // Actualización
            var categorySelected = new { option = SelectedOption };
            int a = SelectedOption;
            BikeDto.Id_BikeCategory = a;
            BikeDto.Availability = true;
            response = await _bike_service.UpdateAsync(BikeDto);
            
        }
        else
        {
            // Inserción
            BikeDto.Availability = true;
            var categorySelected = new { option = SelectedOption };
            int a = SelectedOption;
            BikeDto.Id_BikeCategory = a;
            response = await _bike_service.SaveAsync(BikeDto);
        }
        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        BikeDto = response.Data;
        return RedirectToPage("/BikesManagement/BikesManagement");
    }

}