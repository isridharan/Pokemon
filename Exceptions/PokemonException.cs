using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Exceptions
{
    public class DifferentPokemonException : Exception
    {
        public DifferentPokemonException(string message)
        : base(message)
        {
        }
    }

    public class PokemonNotFoundException : Exception
    {
        public PokemonNotFoundException(string message)
        : base(message)
        {
        }
    }

    public class BadRequestFormatException : Exception
    {
        public BadRequestFormatException(string message)
        : base(message)
        {
        }

    }

    public class BadResponseFormatException : Exception
    {
        public BadResponseFormatException(string message)
        : base(message)
        {
        }

    }

    public class PokemonClientException : Exception
    {
        public PokemonClientException(string message)
       : base(message)
        {
        }
    }
}
