using Newtonsoft.Json;

namespace SwaggerAPITesting.Models{
    public class OrderModel{

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("petId")]
        public long PetId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("shipDate")]
        public string ShipDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("complete")]
        public bool Complete { get; set; }
    }

    public enum OrderStatus{

        placed,
        approved,
        delivered
    }
    
}
