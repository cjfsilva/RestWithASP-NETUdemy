using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Data.VO
{
    public class Person2VO : ISupportsHyperMedia
    {
        //[JsonPropertyName("codigo")]
        public long? Id { get; set; }

        //[JsonPropertyName("primeiroNome")]
        public string FirstName { get; set; }

        //[JsonIgnore]
        public string LastName { get; set; }

        //[JsonPropertyName("endereco")]
        public string Address { get; set; }

        //[JsonPropertyName("genero")]
        public string Gender { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
