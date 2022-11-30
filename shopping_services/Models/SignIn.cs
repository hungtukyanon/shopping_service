using System.ComponentModel.DataAnnotations;

namespace shopping_services.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(100)]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(100)]
        public string password { get; set; }
    }
}
