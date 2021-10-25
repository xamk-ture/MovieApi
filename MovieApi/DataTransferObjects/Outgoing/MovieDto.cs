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

        public List<string> Categories { get; set; }

    }

    public class MovieDtoProfile : Profile
    {
        public MovieDtoProfile()
        {
            //For categories property this mapper firstly selects Movie entitys MoviesCategories property and then
            //it selects all MovieCategories Category.Name propertys and creates new list to map easily all categories name
            //to the dto Categories property
            CreateMap<Models.Movie, MovieDto>()
                .ForMember(movieDto => movieDto.Categories, 
                x => x.MapFrom(movieEntity => new List<string>(movieEntity.MovieCategories.Select(c => c.Category.Name))));
        }
    }
}
