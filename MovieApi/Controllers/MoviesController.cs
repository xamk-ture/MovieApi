using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.DataTransferObjects.Outgoing;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            //Tämä koodi vastaa alla olevaa koodia, ProjectTo<MovieDto>(_mapper.ConfigurationProvider) ajaa saman asian mitä alla oleva koodi
            //var movies = await _context.Movies
            //    .Include(x => x.Crews).ThenInclude(x => x.Actor).ThenInclude(x => x.Person)
            //    .AsNoTracking()
            //    .ToListAsync();

            //var movieDtos = _mapper.Map<List<MovieDto>>(movies);

            //return movieDtos;

            return await _context.Movies
                .Include(x => x.Actors).ThenInclude(x => x.Person)
                .AsNoTracking()
                .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("GetMovieWithReviews/{id}")]
        public async Task<ActionResult<MovieDto>> GetMovieWithReviews(long id)
        {
            var movie = await _context.Movies.Include(x => x.Reviews).SingleOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            //Code below represents what _mapper.Map<MovieDto>(movie) actually does "behind secenes"
            //var movieDto = new MovieDto
            //{
            //    Name = movie.Name,
            //    Description = movie.Description,
            //    ReleaseDate = movie.ReleaseDate,
            //    Id = movie.Id
            //};

            //foreach (var review in movie.Reviews)
            //{
            //    var reviewDto = new ReviewDto()
            //    {
            //        Id = review.Id,
            //        Rating = review.Rating,
            //        IsCriticRated = review.IsCriticRated,
            //        MovieId = review.MovieId
            //    };

            //    movieDto.Reviews.Add(reviewDto);
            //}

            return _mapper.Map<MovieDto>(movie);
        }

        [HttpGet("GetMovieReviewTexts/{id}")]
        public async Task<ActionResult<IEnumerable<string>>> GetMovieReviewTexts(long id, bool showOnlyCriticReviews = false)
        {
            //Example query where only fetch all movies reviews texts and nothing else and with optional query parameter that shows only critics or non critics texts
            var allReviewTexts = _context.Movies.Include(x => x.Reviews)
                .SingleOrDefault(x => x.Id == id)?
                .Reviews.Where(x => x.IsCriticRated == showOnlyCriticReviews)
                .Select(x => x.Text);

            return allReviewTexts.ToList();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(long id)
        {
            //Example query where only fetch all movies reviews texts and nothing else and with optional query parameter
            //var allReviewTexts = _context.Movies.Include(x => x.Reviews)
            //    .SingleOrDefault(x => x.Id == id)?
            //    .Reviews.Where(x => x.IsCriticRated == showOnlyCriticReviews)
            //    .Select(x => x.Text);

            var movie = await _context.Movies
                .Include(x => x.Actors).ThenInclude(x => x.Person)
                .Include(x => x.Directors).ThenInclude(x => x.Person)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var movieDto = _mapper.Map<MovieDto>(movie);

            return movieDto;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(long id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(long id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
