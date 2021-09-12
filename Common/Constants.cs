using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Common
{
    public class Constants
    {      
        public struct PokemonException
        {
            public const string PokemonClientException = "Error occured when fetching pokemon data from client";
            public const string PokemonNotFoundException = "Pokemon not found";
            public const string DifferentPokemonException = "Different Pokemon has been returned";
            public const string RequestFormatException = "The parameter (name) accepts only characters(a-z) lower cases";           
        }

        public struct GeneralException
        {
            public const string InternalServerError = "Error Occured while processing your request.";
        }

        public struct ClientException
        {
            public const string BadResponseFormatException = "Incompatible response format returned from client";
        }

        public struct TranslationException
        {
            public const string TranslateClientException = "Error occured when fetching translation data from client";  
            public const string Shakespeare = "shakespeare";
        }

    }   
}
