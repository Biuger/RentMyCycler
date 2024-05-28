using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.CatalogBikes;

public class CatalogBikes : PageModel
{
    [BindProperty] public UserDto UserDto { get; set; }
    
    private readonly IBikeService _service;
    private readonly IUserService _userService;
    
    public List<BikeDto> Bikes { get; set; }

    public CatalogBikes(IBikeService service, IUserService userService)
    {
        Bikes = new List<BikeDto>();
        _userService = userService;
        _service = service;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        //La llamada al servicio
        var response = await _service.GetAllAsync();
        Bikes = response.Data;
        
        UserDto = new UserDto();
        var responseUser = await _userService.GetById(id.Value);
        UserDto = responseUser.Data;
        
        var Id = responseUser.Data.id;
        TempData["id"] = Id;
        
        return Page();
    }
}