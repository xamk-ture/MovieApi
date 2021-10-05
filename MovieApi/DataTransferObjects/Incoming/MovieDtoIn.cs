using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.DataTransferObjects.Incoming
{
    public class MovieDtoIn
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? Description { get; set; }

    }

    public class MovieDtoProfile : Profile
    {
        public MovieDtoProfile()
        {
            CreateMap<Models.Movie, MovieDtoIn>().ReverseMap();
        }
    }
}
