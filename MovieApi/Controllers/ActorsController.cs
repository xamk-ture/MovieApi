using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.DataTransferObjects.Outgoing;
using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public ActorsController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Actors/GetMovieActors
        [HttpGet("GetMovieActors/{movieId}")]
        public async Task<ActionResult<IEnumerable<MovieActorDto>>> GetMovieActors(long movieId)
        {
            var movieActors = await _context.Actors.Include(x => x.Person)
                .Where(x => x.MovieId == movieId).OrderBy(x => x.Person.LastName).ToListAsync();

            return _mapper.Map<List<MovieActorDto>>(movieActors);
        }
    }
}
