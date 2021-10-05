using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<MovieContext>();

                GenerateMovieData(context);
                GenerateCrewData(context, 1);

                context.SaveChanges();
            }

            host.Run();
        }

        private static void GenerateMovieData(MovieContext context)
        {
            //You can add here new objects to the in memory database, so you have some data when you are starting up the project
            var movie1 = new Movie()
            {
                Name = "Testi elokuva",
                Description = "Testi kuvaus",
                SecretInfo = "Ei asiakkaille nähtäväksi!",
                Reviews = new List<Review>() { new Review() { Rating = 5, Text = "Viisi tähteä" }, new Review() { Rating = 3, Text = "Kolme tähteä", IsCriticRated = true } }
            };

            context.Movies.Add(movie1);

            var movie2 = new Movie()
            {
                Name = "Elokuva kaksi",
                Description = "Kaksi kuvaus",
                SecretInfo = "Salaista tietoa",
                Reviews = new List<Review>() { new Review() { Rating = 1, Text = "Yksi tähteä", IsCriticRated = true } }
            };

            context.Movies.Add(movie2);
        }

        /// <summary>
        /// Generates crew data to given movie
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="movieId">MovieId to what movie to generate the data</param>
        private static void GenerateCrewData(MovieContext context, long movieId)
        {
            var actorPerson = new Person();
            actorPerson.FirstName = "Pena";
            actorPerson.Id = 1;

            context.Persons.Add(actorPerson);


            var actor = new Actor();
            actor.Id = 1;
            actor.PersonId = actorPerson.Id;
            actorPerson.Actor = actor;

            context.Actors.Add(actor);

            //var actorCrew = new Crew();
            //actorCrew.ActorId = actor.Id;
            //actorCrew.MovieId = movieId;

            //context.Crews.Add(actorCrew);


            var directorPerson = new Person();
            directorPerson.FirstName = "Ohjaaja mies";
            directorPerson.Id = 2;

            context.Persons.Add(directorPerson);

            var director = new Director();
            director.Id = 1;
            director.Person = directorPerson;

            context.Directors.Add(director);

            //var directorCrew = new Crew();
            //directorCrew.Director = director;
            //directorCrew.MovieId = movieId;

            //context.Crews.Add(directorCrew);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
