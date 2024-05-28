using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.BikeCategories;

public class Delete : PageModel
{
    [BindProperty] public BikeCategoryDto BikeCategoryDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();

    private readonly IBikeCategoryService _service;

    public Delete(IBikeCategoryService service)
    {
        _service = service;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        BikeCategoryDto = new BikeCategoryDto();
        var response = await _service.GetById(id);
        BikeCategoryDto = response.Data;

        if (BikeCategoryDto == null)
        {
            return RedirectToPage("/Error");
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(BikeCategoryDto.id);
        return RedirectToPage("/BikeCategories/BikeCategories");
        
    }
}