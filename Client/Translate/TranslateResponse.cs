using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Client.Translate
{
    [Serializable]
    public class TranslateResponse
    {
        public Content contents { get; set; }
    }

    public class Content
    {
        public string translated { get; set; }
        public string text { get; set; }
        public string translation { get; set; }
    }
    
}
