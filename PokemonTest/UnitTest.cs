using AutoMapper;
using NUnit.Framework;
using Pokedex.Client;
using Pokedex.Mapper;
using Pokedex.Services;
using Pokedex.Exceptions;
using System;

namespace PokemonTest
{
    public class PokemonServiceTest
    {
        PokemonService pokemonService;
        [SetUp]
        public void Setup()
        {
            // Arrange
            var translationclient = new TranslateClient();
            var translationService = new TranslationService(translationclient);

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PokemonProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var pokemonclient = new PokemonClient();
            pokemonService = new PokemonService(pokemonclient, mapper, translationService);
        }

        [Test]
        public void GetPokemonHappyPath()
        {
            //Act
            var name = "mewtwo";
            var task = pokemonService.GetPokemonAsync(name);

            //Assert
            Assert.IsTrue(task.Result.Name == name);
        }

        [Test]
        public void GetPokemonRequestFormat1()
        {
            try
            {
                //Act
                var name = "11";
                var task = pokemonService.GetPokemonAsync(name);

            }
            catch(Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is BadRequestFormatException);
            }            
        }

        [Test]
        public void GetPokemonRequestFormat2()
        {
            try
            {
                //Act
                var name = "Mewtwo";
                var task = pokemonService.GetPokemonAsync(name);

            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is BadRequestFormatException);
            }
        }


        [Test]
        public void GetPokemonRequestFormat3()
        {
            try
            {
                //Act
                var name = "mewTwo";
                var task = pokemonService.GetPokemonAsync(name);

            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is BadRequestFormatException);
            }
        }

        [Test]
        public void GetPokemonNoPokemonFound()
        {
            try
            {
                //Act
                var name = "abcde";
                var task = pokemonService.GetPokemonAsync(name);

            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is PokemonNotFoundException);
            }
        }

        [Test]
        public void GetTranslationHappyPath()
        {          
                //Act
                var name = "mewtwo";
                var task = pokemonService.GetTranslatedPokemonAsync(name);
                var task1 = pokemonService.GetPokemonAsync(name);
                var pokemontranslated = task.Result;
                var pokemon = task1.Result;

            //Assert Successful Translation
            Assert.IsTrue(pokemon.Description != null && pokemon.Description != pokemontranslated.Description);
        }

        [Test]
        public void IfTranslationIsDefaulted()
        {
            //Act
            var name = "mewtwo";
            var taskpokemon = pokemonService.GetPokemonAsync(name);

            for(int i = 0; i<=4; i++)
            {
                var taskTranslatedRepeat = pokemonService.GetTranslatedPokemonAsync(name);
            }
            var taskTranslated = pokemonService.GetTranslatedPokemonAsync(name);            

            var pokemontranslated = taskTranslated.Result;
            var pokemon = taskpokemon.Result;
            
            //Assert If Translation failed, descsription is successfully defaulted.
            Assert.IsTrue(pokemon.Description != null && pokemon.Description == pokemontranslated.Description);
        }
    }
}