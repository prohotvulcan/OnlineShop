using System.ComponentModel.DataAnnotations;

namespace olShop.WebApp.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string UserName { get; set; }

        public bool IsMailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name ="Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
