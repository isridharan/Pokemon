using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Client.Translate
{
    public class TranslateRequest
    {
        public TranslateRequest(string description)
        {
            this.text = description;
        }
        public string text { get; set; }         
    }
}
