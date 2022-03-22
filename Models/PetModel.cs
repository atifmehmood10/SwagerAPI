using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwaggerAPITesting.Models
{


    //Category
    public class CategoryModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    //Tags
    public class TagModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    // Pet model
    public class PetModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public CategoryModel Category { get; set; }

        [JsonProperty("photoUrls")]
        public List<string> PhotoUrls { get; set; }

        [JsonProperty("tags")]
        public List<CategoryModel> Tags { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

    }


    public enum PetStatus{
        available,
        pending,
        sold
    }

}
