using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentMyCycler.Api.DTO;
using RentMyCycler.Core.http;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Pages.SignUp
{
    public class SignUp : PageModel
    {
        private readonly IUserService _service;
        private readonly IBikeCategoryService _bikeService;
        
        public List<BikeCategoryDto> BikeCategories { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        
        [BindProperty]
        public UserDto UserDto { get; set; }
        
        public SignUp(IUserService service, IBikeCategoryService bikeCategory)
        {
            BikeCategories = new List<BikeCategoryDto>();
            _service = service;
            _bikeService = bikeCategory;
        }
        
        
        public async Task<IActionResult> OnGet()
        {
            var response = await _bikeService.GetAllAsync();
            BikeCategories = response.Data;
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            

            Response<UserDto> response;
            
            //Insercción
            UserDto.Image = "https://www.tenforums.com/geek/gars/images/2/types/thumb_15951118880user.png";
            string cyclingPreferences = Request.Form["CyclingPreferences"];
            UserDto.Cycling_preferences = cyclingPreferences;
            response = await _service.SaveAsync(UserDto);

            Errors = response.Errors;

            if (Errors.Count > 0)
            {
                return Page();
            }

            UserDto = response.Data;
            return RedirectToPage("/Home/Home");
        }

    }
}