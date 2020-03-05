using Newtonsoft.Json;

namespace Training.DTO
{
    public class OrderProduct
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}
