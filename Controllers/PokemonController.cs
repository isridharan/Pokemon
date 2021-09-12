using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Exceptions;
using Pokedex.Services;
using Pokedex.Common;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("{controller}/")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
    
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello, Welcome to pokemon api");
        }

        [HttpGet]
        [Route("{name}")]
      public async Task<ActionResult> GetPokemonAsync(string name)
        {
            try
            {               
                var pokemon = await _pokemonService.GetPokemonAsync(name);               
                return Ok(pokemon);                                
            }
            catch(Exception ex)
            {
               return HandleException(ex);
            }           
        }

        [HttpGet]
        [Route("translated/{name}")]
        public async Task<ActionResult> GetTranslatedPokemonAsync(string name)
        {
            try
            {
                var pokemon = await _pokemonService.GetTranslatedPokemonAsync(name);                               
                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        private ActionResult HandleException(Exception ex)
        {
            if (ex is PokemonNotFoundException)
            {
                return NotFound(ex.Message);
            }

            if (ex is DifferentPokemonException)
            {
                return NotFound(ex.Message);
            }

            if (ex is BadRequestFormatException)
            {
                return BadRequest(ex.Message);
            }

            if (ex is BadResponseFormatException)
            {
                return StatusCode(500, Constants.GeneralException.InternalServerError + ex.Message);
            }

            if (ex is PokemonClientException)
            {
                return StatusCode(500, Constants.GeneralException.InternalServerError + ex.Message);
            }                             
            return StatusCode(500, Constants.GeneralException.InternalServerError + ex.Message);
        }
    }
}
