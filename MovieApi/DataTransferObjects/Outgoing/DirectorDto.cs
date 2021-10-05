using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.DataTransferObjects.Outgoing
{
    public class DirectorDto : BaseDto
    {
        public long PersonId { get; set; }

        public PersonDto Person { get; set; }

        public long MovieId { get; set; }

        public MovieDto Movie { get; set; }

    }

    public class DirectorDtoProfile : Profile
    {
        public DirectorDtoProfile()
        {
            CreateMap<Models.Director, DirectorDto>().ReverseMap();
        }
    }
}
