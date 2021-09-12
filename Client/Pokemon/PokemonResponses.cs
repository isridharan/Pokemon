using Pokedex.Exceptions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pokedex.Client.Response
{      
    [Serializable]
    public class PokemonResponse 
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<DescriptionSpecies> flavor_text_entries { get; set; }
        public bool? is_legendary { get; set; }
        public PokemonHabitat habitat { get; set; }

        public bool isValid(string name)
        {                      
            return this.name == name;
        }

        public struct LanguageSpecies
        {
            public const string English = "en";
        }      

        public string GetDescription()
        {
            var description = flavor_text_entries.Where(x => x.language.name == LanguageSpecies.English).Select(x => x.flavor_text).FirstOrDefault();           
            var regex = new Regex(@"\r\n\f?|\n|\t|\f", RegexOptions.Compiled);
            description = regex.Replace(description, " ");
            return description;
        }
    }

    [Serializable]
    public class PokemonHabitat
    {
        public string name { get; set; }
    }

    [Serializable]
    public class DescriptionSpecies
    {
        public string flavor_text { get; set; }
        public LanguageSpecies language { get; set; }     
    }

    [Serializable]
    public class LanguageSpecies
    {
        public string name { get; set; }        
    }
}
