using Microsoft.AspNetCore.Mvc;
using Pokedex.Client.Translate;
using Pokedex.Common;
using Pokedex.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Client
{
    public interface ITranslateClient
    {
        public Task<TranslateResponse> GetTranslationAsync(string translator, TranslateRequest request);
    }

    public class TranslateClient : ITranslateClient
    {
        private readonly string _uri = "https://api.funtranslations.com/translate/";
        public TranslateClient()
        {

        }

        public async Task<TranslateResponse> GetTranslationAsync(string translator,TranslateRequest request)
        {
            try
            {
                    var client = new RestClient(_uri);                   
                    var req = new RestRequest(translator, Method.POST,DataFormat.Json);                   
                    req.AddHeader("Content-Type", "application/json");
                    var body = JsonConvert.SerializeObject(request);
                    req.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = await client.ExecuteAsync(req);

                if (response.IsSuccessful)
                {
                    // if response format is acceptable
                    if (UtilityService.IsStringJSON(response.Content))
                    {
                        var responseTranslate = JsonConvert.DeserializeObject<TranslateResponse>(response.Content);
                        return responseTranslate;
                    }
                    else
                    {
                        // In ideal case this request has to be logged from our end.
                        throw new BadResponseFormatException(Constants.ClientException.BadResponseFormatException);
                    }                   
                }
                return default;
            }
            catch (Exception ex)
            {
                // In ideal case this request has to be logged from our end. 
                // We should have a config for retry "x" number of times and stop making this request once the attempts are exceeded.
                // This might indicate the client API is down.
                throw new TranslateClientException(Constants.TranslationException.TranslateClientException + ex.Message);
            }

        }
    }
}
