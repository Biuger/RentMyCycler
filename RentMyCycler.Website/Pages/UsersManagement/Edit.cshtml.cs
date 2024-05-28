using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Core.http;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.UsersManagement;

public class Edit : PageModel
{
    [BindProperty] public UserDto UserDto { get; set; }
    [NotMapped]
    public string BirthdateFormatted => UserDto.Birthdate.ToString("yyyy-MM-dd");

    public List<string> Errors { get; set; } = new List<string>();
    public List<BikeCategoryDto> BikeCategories { get; set; }

    private readonly IUserService _service;
    private readonly IBikeCategoryService _bikeService;

    public Edit(IUserService service, IBikeCategoryService bikeCategory)
    {
        BikeCategories = new List<BikeCategoryDto>();
        _service = service;
        _bikeService = bikeCategory;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        UserDto = new UserDto();
        
        var responseBikeCategory = await _bikeService.GetAllAsync();
        BikeCategories = responseBikeCategory.Data;
        
        
        if (id.HasValue)
        {
            //Obtener informacion del servicio API
            var response = await _service.GetById(id.Value);
            UserDto = response.Data;
        }

        if (UserDto == null)
        {
            return RedirectToPage("/Error");
        }

        
        UserDto.Birthdate =  DateOnly.Parse(BirthdateFormatted);
      
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        Response<UserDto> response;
       
        //Actualización
        string cyclingPreferences = Request.Form["CyclingPreferences"];
        UserDto.Cycling_preferences = cyclingPreferences;
        response = await _service.UpdateAsync(UserDto);

        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        UserDto = response.Data;
        return RedirectToPage("/UsersManagement/UsersManagement");
    }
}