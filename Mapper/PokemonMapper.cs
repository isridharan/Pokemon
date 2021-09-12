using AutoMapper;
using Pokedex.Client.Response;
using Pokedex.Services.DTO;
using Pokedex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Mapper
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {           
            CreateMap<PokemonResponse, Poke>()
              .ForMember(x => x.Name, o => o.MapFrom(x => x.name))
              .ForMember(x => x.IsLegendary, o => o.MapFrom(x => x.is_legendary))
              .ForMember(x => x.Description, o => o.MapFrom(x => x.GetDescription()))
              .ForMember(x => x.Habitat, o => o.MapFrom(x => x.habitat.name));

            CreateMap<Poke, PokemonDTO>()
             .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
             .ForMember(x => x.IsLegendary, o => o.MapFrom(x => x.IsLegendary))
             .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
             .ForMember(x => x.Habitat, o => o.MapFrom(x => x.Habitat));

            CreateMap<Poke, PokemonTranslatedDTO>()
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.IsLegendary, o => o.MapFrom(x => x.IsLegendary))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.TranslatedDescription))
            .ForMember(x => x.Habitat, o => o.MapFrom(x => x.Habitat));
        }
    }
}
