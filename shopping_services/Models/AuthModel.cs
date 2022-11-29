using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_services.Models
{
    public class AuthModel
    {
        [Required]
        [MaxLength(100)]
        public string username { get; set; }
        [Required]
        [MaxLength(100)]
        public string password { get; set; }
        [Required]
        [MaxLength(100)]
        public string email { get; set; }
    }
}
