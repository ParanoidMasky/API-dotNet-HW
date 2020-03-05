
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Training.DTO
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("fullName")]
        [MaxLength(100)]
        public string FullName { get; set; }

        [JsonProperty("email")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [MaxLength(100)]
        public string Email { get; set; }
        
        [JsonProperty("gender")]
        [RegularExpression("Male|Female", ErrorMessage = "Invalid Gender, Only Male, Female accepted")]
        public string Gender { get; set; }
    }
}
