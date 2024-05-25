using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentMyCycler.Website.Pages;

public class IndexModel : PageModel
{
    
    [BindProperty]
    public InputModel Input { get; set; }
    
    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        int test = 1;
        
        if (test == 1)
        {
            return RedirectToPage("/Home/Home");
        }
        else
        {
            return Page();
        }
    }
    
    public void OnGet()
    {
        
    }
}