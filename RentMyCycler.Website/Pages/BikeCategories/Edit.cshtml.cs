using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Core.http;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.BikeCategories;

public class Edit : PageModel
{
    [BindProperty] public BikeCategoryDto BikeCategoryDto { get; set; }
    public string Label { get; set; }

    public List<string> Errors { get; set; } = new List<string>();

    private readonly IBikeCategoryService _service;

    public Edit(IBikeCategoryService service)
    {
        _service = service;
    }
    
    public  async Task<IActionResult> OnGet(int? id)
    {
        BikeCategoryDto = new BikeCategoryDto();

        if (id.HasValue)
        {
            //Obtener informacion del servicio API
            var response = await _service.GetById(id.Value);
            BikeCategoryDto = response.Data;
        }
        if (id.Value == 0)
        {
            Label = "New Bike Category";
            return Page();
        }

        if (BikeCategoryDto == null)
        {
            return RedirectToPage("/Error");
        }
        
        Label = "Editing Bike Category";
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<BikeCategoryDto> response;
        if (BikeCategoryDto.id > 0)
        {
            //Actualización
            response = await _service.UpdateAsync(BikeCategoryDto);
        }
        else
        {
            //Insercción
            response = await _service.SaveAsync(BikeCategoryDto);
        }

        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        BikeCategoryDto = response.Data;
        return RedirectToPage("/BikeCategories/BikeCategories");
    }
}