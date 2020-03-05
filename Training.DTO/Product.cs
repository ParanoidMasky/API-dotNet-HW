using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Training.DTO
{
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
