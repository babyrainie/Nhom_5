using System.ComponentModel.DataAnnotations;
namespace dailybook.ViewModels
{
    public class LoginVM
    {
        [Display(Name="Email")]
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
