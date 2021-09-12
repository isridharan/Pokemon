using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Exceptions
{
    public class TranslateClientException : Exception
    {
        public TranslateClientException(string message)
       : base(message)
        {
        }
    }
}
