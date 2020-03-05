using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Training.DTO
{
    public class UserCredentials : User
    {
        [JsonProperty("password")]
        [RegularExpression(".*[0-9].*", ErrorMessage = "Password must contain at least 1 numeric character")]
        public string Password { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
