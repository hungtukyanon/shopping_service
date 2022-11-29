using Microsoft.Build.Framework;
using System.Text.Json.Serialization;

namespace shopping_services.Data
{
    public class User
    {
        public Guid user_id { get; set; }
        [Required]
        public string username { get; set; }

        [JsonIgnore]
        [Required]
        public string password { get; set; }
        public string? email { get; set; }
        public string? RefresherToken { get; set; }
    }
}
