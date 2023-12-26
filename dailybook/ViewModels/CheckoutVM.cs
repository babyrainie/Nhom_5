using System.ComponentModel.DataAnnotations;

namespace dailybook.ViewModels
{
    public class CheckoutVM
    {
        public bool UseInfo { get; set; }
        //public int CustomerId { get; set; }
        public int CustomerId { get; set; }

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string Fullname { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Addresse is required")]
        public string Address { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email")]
        public string Email { get; set; }
        public string Note { get; set; }
    }
}
