using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.DataTransferObjects.Outgoing
{
    public class MovieActorDto : BaseDto
    {
        public long PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

    }

    public class ActorDtoProfile : Profile
    {
        public ActorDtoProfile()
        {
            CreateMap<Models.Actor, MovieActorDto>()
                .ForMember(movieActorDto => movieActorDto.FirstName, x => x.MapFrom(actor => actor.Person.FirstName))
                .ForMember(movieActorDto => movieActorDto.LastName, x => x.MapFrom(actor => actor.Person.LastName))
                .ForMember(movieActorDto => movieActorDto.BirthDate, x => x.MapFrom(actor => actor.Person.BirthDate));
        }
    }
}
