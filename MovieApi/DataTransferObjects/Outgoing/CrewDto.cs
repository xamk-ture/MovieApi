using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.DataTransferObjects.Outgoing
{
    public class CrewDto
    {
        public long ActorId { get; set; }
    }

    public class CrewDtoProfile : Profile
    {
        public CrewDtoProfile()
        {
            CreateMap<Models.Crew, CrewDto>().ReverseMap();
        }
    }
}
