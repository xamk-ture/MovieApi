using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.DataTransferObjects.Outgoing
{
    public class MovieDto : BaseDto
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? Description { get; set; }

        public string TestiTeksti { get; set; }

        public List<ReviewDto> Reviews { get; set; }

        public List<MovieActorDto> Actors { get; set; }

        //public List<ActorDto> Directors { get; set; }

    }

    public class MovieDtoProfile : Profile
    {
        public MovieDtoProfile()
        {
            CreateMap<Models.Movie, MovieDto>().ReverseMap();
        }
    }
}
