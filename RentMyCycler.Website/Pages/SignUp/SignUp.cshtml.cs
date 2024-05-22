using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentMyCycler.Website.Pages.SignUp
{
    public class SignUp : PageModel
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
           
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime Birthdate { get; set; }

            [Required]
            public string Address { get; set; }

            [Required]
            public string CyclingPreferences { get; set; }
        }
        
        public void OnGet()
        {
            
        }
    }
}