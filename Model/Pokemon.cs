using Pokedex.Infrastructure;

namespace Pokedex.Model
{  
    public class Poke : Entity<int>
    {           
        public override int Id { get; set; }
        public string Name { get; set; }      
        public string Description { get; set; }
        public string Habitat { get; set; }
        public bool? IsLegendary { get; set; }
        public string TranslatedDescription { get; private set; }


        public struct PokemonTranslation
        {
            public const string Yoda = "yoda";
            public const string Shakespeare = "shakespeare";
        }

        public struct PokemonHabitat
        {
            public const string Cave = "Cave";
        }

        public string GetTranslationType()
        {
            if (this.Habitat == PokemonHabitat.Cave || (this.IsLegendary.HasValue && this.IsLegendary.Value == true))
                return PokemonTranslation.Yoda;
            else
                return PokemonTranslation.Shakespeare;
        }

        public void SetTranslatedDescription( string translatedDescription)
        {
            this.TranslatedDescription = translatedDescription;
        }

        public override bool IsValid()
        {
           return this.Id > 0 && string.IsNullOrEmpty(this.Name);
        }
    }
}
