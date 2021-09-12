using Pokedex.Client;
using Pokedex.Client.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    public interface ITranslationService
    {
        public Task<string> GetTranslationAsync(string translator, string description);
    }

    public class TranslationService : ITranslationService
    {
        public readonly ITranslateClient _translationClient;
        public TranslationService(ITranslateClient translationClient)
        {
            _translationClient = translationClient;
        }
      
        public async Task<string> GetTranslationAsync(string translator, string description)
        {
            var clientRequest = new TranslateRequest(description);
            var clientResponse = await _translationClient.GetTranslationAsync(translator, clientRequest);
            if (clientResponse == default(TranslateResponse))
            {
                return default;
            }
            else
                return clientResponse.contents.translated;            
        }     
    }
}
 