using Pokedex.Client;
using Pokedex.Exceptions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Pokedex.Client.Response;
using Pokedex.Services.DTO;
using Pokedex.Model;
using Pokedex.Common;

namespace Pokedex.Services
{
    public interface IPokemonService
    {
        public Task<PokemonDTO> GetPokemonAsync(string name);
        public Task<PokemonTranslatedDTO> GetTranslatedPokemonAsync(string name);
    }

    public class PokemonService : IPokemonService
    {
        private readonly IPokemonClient _pokemonClient;
        private readonly ITranslationService _translationService;
        private readonly IMapper _mapper;        

        public PokemonService(IPokemonClient pokemonClient, IMapper mapper, ITranslationService translationService)
        {
            _pokemonClient = pokemonClient;
            _translationService = translationService;
            _mapper = mapper;
        }
        public async Task<PokemonDTO> GetPokemonAsync(string name)
        {
            var pokemon = await getPokemon(name);
            return _mapper.Map<PokemonDTO>(pokemon);                  
        }
        public async Task<PokemonTranslatedDTO> GetTranslatedPokemonAsync(string name)
        {
            var pokemon = await getPokemon(name);
            var translationType = pokemon.GetTranslationType();
            var translatedresponse = await _translationService.GetTranslationAsync(translationType, pokemon.Description);
            if (translatedresponse != default)
            {
                pokemon.SetTranslatedDescription(translatedresponse);
            }
            else
                pokemon.SetTranslatedDescription(pokemon.Description);

            return _mapper.Map<PokemonTranslatedDTO>(pokemon);
        }

        private async Task<Poke> getPokemon(string name)
        {
            var isValid = UtilityService.IsAllLowerCase(name);
            if (!isValid)
            {
                throw new BadRequestFormatException(Constants.PokemonException.RequestFormatException);
            }
            var clientResponse = await _pokemonClient.GetPokemonAsync(name);
            if (clientResponse == default(PokemonResponse))
            {
                throw new PokemonNotFoundException(Constants.PokemonException.PokemonNotFoundException);
            }

            if (clientResponse.isValid(name))
            {
                return _mapper.Map<Poke>(clientResponse);
            }
            else
            {
                throw new DifferentPokemonException(Constants.PokemonException.DifferentPokemonException);
            }
        }
    }
}
