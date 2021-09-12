using Microsoft.AspNetCore.Mvc;
using Pokedex.Client.Response;
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
    public interface IPokemonClient
    {
        public Task<PokemonResponse> GetPokemonAsync(string name);
    }

    public class PokemonClient : IPokemonClient
    {
        private const string _uri = "https://pokeapi.co/";
        public PokemonClient()
        {
            
        }          
        public async Task<PokemonResponse> GetPokemonAsync(string name)
        {
            try
            {
                //_uri to be moved to config file too
                var client = new RestClient(_uri);
                var request = new RestRequest("api/v2/pokemon-species/{name}", Method.GET);
                request.AddParameter("name", name, ParameterType.UrlSegment);
                request.AddHeader("Content-Type", "application/json");
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {         
                    // if response format is acceptable
                    if (UtilityService.IsStringJSON(response.Content))
                    {
                        var responsePokemon = JsonConvert.DeserializeObject<PokemonResponse>(response.Content);
                        return responsePokemon;
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
                throw new PokemonClientException(Constants.PokemonException.PokemonClientException + ex.Message);
            }
        }       
    }
}
