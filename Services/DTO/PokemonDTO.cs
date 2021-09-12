using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Services.DTO
{
    [Serializable]
    public class PokemonDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("habitat")]
        public string Habitat { get; set; }
        [JsonProperty("is_Legendary")]
        public bool? IsLegendary { get; set; }       
    }

    [Serializable]
    public class PokemonTranslatedDTO : PokemonDTO
    {
        
    }
}
