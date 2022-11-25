using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_services.Models
{
    [Table("User")]
    public class User
    {
        public Guid user_id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

    }
}
