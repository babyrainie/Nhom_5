using System.ComponentModel.DataAnnotations;

namespace dailybook.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        //[Required(ErrorMessage = "*")]
        //public int CusId { get; set; }

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string Fullname { get; set; } = null!;

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? Dob { get; set; }

        [Display(Name = "Avatar")]
        public string? Ava { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; } = null!;
    }
}
