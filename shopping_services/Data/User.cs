using System.Text.Json.Serialization;

namespace shopping_services.Data
{
    public class User
    {
        public Guid user_id { get; set; }
        public string username { get; set; }

        [JsonIgnore]
        public string password { get; set; }
        public string email { get; set; }
    }
}
