using Newtonsoft.Json;
using System.Collections.Generic;

namespace Training.DTO
{
    public class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("order_products")]
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
