using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.DataTransferObjects.Outgoing
{
    public class ReviewDto
    {
        public long Id { get; set; }

        public double Rating { get; set; }

        public bool IsCriticRated { get; set; }

        public string? Text { get; set; }

        public string MovieId { get; set; }

    }

    public class ReviewDtoProfile : Profile
    {
        public ReviewDtoProfile()
        {
            CreateMap<Models.Review, ReviewDto>().ReverseMap();
        }
    }
}
