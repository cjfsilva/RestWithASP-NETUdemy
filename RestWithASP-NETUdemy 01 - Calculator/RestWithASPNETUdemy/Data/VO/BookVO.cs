using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        [JsonPropertyName("codigo")]
        public long? Id { get; set; }

        [JsonPropertyName("titulo")]
        public string Title { get; set; }

        //[JsonIgnore]
        public string Author { get; set; }

        [JsonPropertyName("preco")]
        public decimal Price { get; set; }

        [JsonPropertyName("data")]
        public DateTime LaunchDate { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
